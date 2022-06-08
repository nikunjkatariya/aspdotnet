using EDIParser.Models;
using EDIParser.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EDIParser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly ICosmosDBService _service;
        public ContainerController(ICosmosDBService cosmosDBService)
        {
            _service = cosmosDBService??throw new ArgumentNullException(nameof(cosmosDBService));
        }
         // GET api/<ContainerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _service.GetAsync(id));
        }

        // POST api/<ContainerController>
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            /*            containerData.Id = Guid.NewGuid().ToString();*/
/*            Watchlist watchlist = new Watchlist();
            watchlist = await Parser.EDIParser(watchlist);*/

            Watchlist container = new Watchlist();
            string SenderId = "", InterchangeControlNumber = "", GroupControlNumber = "", TransactionControlNumber = "";
            string dirpath = @"D:\EDITransactions\Transactions";
            string targetpath = @"D:\EDITransactions\Completed";
            string[] FileNames = Directory.GetFiles(dirpath, "*.txt");
            
            if (FileNames.Length != 0)
            {                
                string edipath = @"D:\EDITransactions\Transactions\EDITest.txt";

                StreamReader sr = new StreamReader(edipath);
                char[] delimeters = { '~', '\n' };
                string[] edilines = sr.ReadToEnd().ToString().Split(delimeters).Where(p => !string.IsNullOrWhiteSpace(p)).ToArray();

                container.Segment = new Segment();//B4
                container.ReferenceIdentification = new ReferenceIdentification();//N9
                container.ReferenceIdentification.Fees = new List<Fees>();//N9:Fees
                container.ReferenceIdentification.SupportedValues = new List<SupportedValues>();//N9:Codes
                container.Status = new Status();//Q2
                container.ShipmentStatus = new List<ShipmentStatus>();//SG
                container.PortOrTerminal = new List<PortOrTerminal>();//R4
                                                                      //container.DTReference = new DTReference();//DTM

                for (int i = 0; i < edilines.Length; i++)
                {
                    string[] Statementline = Array.ConvertAll(edilines[i].Split('*'), a => a.Trim());
                    switch (Statementline[0])
                    {
                        case "ISA":
                            SenderId = Statementline[6];
                            string[] IEARecord = Array.ConvertAll(edilines[edilines.Length - 1].Split('*'), a => a.Trim());
                            if (Statementline[13] == IEARecord[2])
                            {
                                InterchangeControlNumber = Statementline[13];
                            }
                            else
                            {
                                return Ok("Interchange Code is Not Matched!");
                                break;
                            }
                            break;
                        case "GS":
                            if (InterchangeControlNumber != "")
                            {
                                if (Statementline[2] == SenderId)
                                {
                                    string[] GERecord = Array.ConvertAll(edilines[edilines.Length - 2].Split('*'), a => a.Trim());
                                    if (Statementline[6] == GERecord[2])
                                    {
                                        GroupControlNumber = Statementline[6];
                                    }
                                    else
                                    {
                                        return Ok("Group Records are not Mateched");
                                        break;
                                    }
                                }
                                else
                                {
                                    return Ok("Sender Id is Different!");
                                    break;
                                }
                            }
                            break;
                        case "ST":
                            if (GroupControlNumber != "")
                            {
                                if (Statementline[1] == "315")
                                {
                                    TransactionControlNumber = Statementline[2];
                                }
                            }
                            break;
                        case "B4":
                            if (TransactionControlNumber != "")
                            {
                                //Container Id Initialize
                                container.ContainerId = Statementline[7] + Statementline[8];
                                try
                                {
                                    container.Segment.Code = Statementline[1];
                                    //container.Segment.InquiryRequestNumber = Statementline[2];
                                    container.Segment.ShipmentStatusCode = Statementline[3];
                                    container.Segment.ReleaseDate = Statementline[4];
                                    container.Segment.ReleaseTime = Statementline[5];
                                    //container.Segment.StatusLocation = Statementline[6];
                                    container.Segment.EquipmentInitial = Statementline[7];
                                    container.Segment.EquipmentNumber = Statementline[8];
                                    container.Segment.EquipmentStatusCode = Statementline[9];
                                    container.Segment.EquipmentType = Statementline[10];
                                    //container.Segment.LocationIdentifier = Statementline[11];
                                    //container.Segment.LocationQualifier = Statementline[12];
                                    container.Segment.EquipmentDigit = Statementline[13];
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    //container.Segment.LocationIdentifier = "";
                                    //container.Segment.LocationQualifier = "";
                                    container.Segment.EquipmentDigit = "";
                                }
                                catch (Exception ex)
                                {
                                    return Ok(ex.ToString());
                                }
                            }
                            break;
                        case "N9":
                            if (TransactionControlNumber != "")
                            {
                                //string[] SupportedValues = { "SCA", "AAO", "TI", "GCD", "SN", "ZCD", "BN", "BM", "YS", "EQ", "L1", "TT", "GC" };

                                if (SprtVlusDic.ContainsKey(Statementline[1]))
                                {
                                    container.ReferenceIdentification.SupportedValues.Add(new SupportedValues()
                                    {
                                        Code = SprtVlusDic[Statementline[1]],
                                        ReferenceId = Statementline[2]
                                    });
                                }
                                else
                                {
                                    try
                                    {
                                        container.ReferenceIdentification.Fees.Add(new Fees()
                                        {
                                            Code = FeesDic[Statementline[1]],
                                            Amount = Statementline[2],
                                            Date = Statementline[3]
                                        });
                                    }
                                    catch (IndexOutOfRangeException)
                                    {
                                        container.ReferenceIdentification.Fees.Add(new Fees()
                                        {
                                            Code = FeesDic[Statementline[1]],
                                            Amount = Statementline[2]
                                        });
                                    }
                                }
                            }
                            break;
                        case "Q2":
                            if (TransactionControlNumber != "")
                            {
                                try
                                {
                                    container.Status.VesselCode = Statementline[1];
                                    //container.Status.CountryCode = Statementline[2];
                                    //container.Status.DateOne = Statementline[3];
                                    //container.Status.DateTwo = Statementline[4];
                                    //container.Status.DateThree = Statementline[5];
                                    //container.Status.LadingQuantity = Statementline[6];
                                    container.Status.Weight = Statementline[7];
                                    container.Status.WeightQualifier = Statementline[8];
                                    container.Status.FlightNumber = Statementline[9];
                                    //container.Status.ReferenceIdQualifier = Statementline[10];
                                    //container.Status.ReferenceId = Statementline[11];
                                    container.Status.VesselCodeQualifier = Statementline[12];
                                    container.Status.VesselName = Statementline[13];
                                    //container.Status.Volume = Statementline[14];
                                    //container.Status.VolumeUnitQualifier = Statementline[15];
                                    container.Status.WeightUnitCode = Statementline[16];
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    container.Status.WeightUnitCode = "";
                                }
                            }
                            break;
                        case "SG":
                            if (TransactionControlNumber != "")
                            {
                                try
                                {
                                    container.ShipmentStatus.Add(new ShipmentStatus
                                    {
                                        ShipmentStatusCode = Statementline[1],
                                        //StatusReasonCode = Statementline[2],
                                        //DispositionCode = Statementline[3],
                                        Date = Statementline[4],
                                        Time = Statementline[5]
                                    });
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    container.ShipmentStatus.Add(new ShipmentStatus
                                    {
                                        ShipmentStatusCode = Statementline[1],
                                        //StatusReasonCode = Statementline[2],
                                        //DispositionCode = Statementline[3],
                                        Date = Statementline[4],
                                    });
                                }
                            }
                            break;
                        case "R4":
                            if (TransactionControlNumber != "")
                            {
                                try
                                {
                                    container.PortOrTerminal.Add(new PortOrTerminal
                                    {
                                        FunctionCode = Statementline[1],
                                        LocationQualifier = Statementline[2],
                                        LocationIdentifier = Statementline[3],
                                        PortName = Statementline[4],
                                        CountryCode = Statementline[5],
                                        TerminalName = Statementline[6],
                                        PierName = Statementline[7],
                                        StateCode = Statementline[8]
                                    });
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    container.PortOrTerminal.Add(new PortOrTerminal
                                    {
                                        FunctionCode = Statementline[1],
                                        LocationQualifier = Statementline[2],
                                        LocationIdentifier = Statementline[3],
                                        PortName = Statementline[4],
                                        CountryCode = Statementline[5]
                                    });
                                }
                            }
                            break;
                        //case "DTM":
                        //    if (TransactionControlNumber != "")
                        //    {
                        //        container.DTReference.Qualifier = Statementline[1];
                        //        container.DTReference.Date = Statementline[2];
                        //        container.DTReference.Time = Statementline[3];
                        //        container.DTReference.TimeCode = Statementline[4];
                        //        container.DTReference.PeriodFormatQualifier = Statementline[5];
                        //        container.DTReference.DTPeriod = Statementline[6];
                        //    }
                        //    break;
                        case "SE":
                            if (TransactionControlNumber != "")
                            {
                                if (TransactionControlNumber == Statementline[2])
                                {
                                    await _service.AddAsync(container);
                                    //container.Segment = null;//B4
                                    //container.ReferenceIdentification = null;//N9
                                    //container.Status = null;//Q2
                                    container.ReferenceIdentification.Fees.Clear();//N9:Fees
                                    container.ReferenceIdentification.SupportedValues.Clear();//N9:Codes
                                    container.ShipmentStatus.Clear();//SG
                                    container.PortOrTerminal.Clear();//R4
                                    TransactionControlNumber = "";
                                }
                                else
                                    return Ok($"Transation Code: {TransactionControlNumber} is Not Matched!");
                            }
                            else
                            {
                                return Ok("Wrong Transaction Format!");
                            }
                            break;
                        case "GE":
                            GroupControlNumber = "";
                            break;
                        case "IEA":
                            InterchangeControlNumber = "";
                            break;
                    }
                }
                //string SourcePath = targetpath + "\\" + Path.GetFileName(FileNames[0]);
                //System.IO.File.Move(FileNames[0], SourcePath);
            }
            return Ok("File Data Uploaded.");
        }

        // PUT api/<ContainerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Watchlist watchlist)
        {
            await _service.UpdateAsync(watchlist.ContainerId, watchlist);
            return Ok();
        }
        static Dictionary<string, string> SprtVlusDic = new Dictionary<string, string>() {
            {"SCA","Standard Carrier Alpha Code"},
            {"AAO","Carrier Assigned Code"},
            {"TI","Transaction Number"},
            {"GCD","Group Code"},
            {"SN","Seal Number"},
            {"ZCD","Zone Code"},
            {"BN","Booking Number"},
            {"BM","Bill of Lading Number"},
            {"YS","Yard Position"},
            {"EQ","Equipment Number"},
            {"L1","Letter Note"},
            {"TT","Terminal Code"},
            {"GC","PIN Number"},
        };

        static Dictionary<string, string> FeesDic = new Dictionary<string, string>() {
            {"22","Special Charge or Allowance Code"},
            {"4I","Day 1 Demurrage"},
            {"4I1","Day 2 Demurrage"},
            {"4I2","Day 3 Demurrage"},
            {"4I3","Day 4 Demurrage"},
            {"4I4","Day 5 Demurrage"},
            {"4I5","Day 6 Demurrage"},
            {"4I6","Day 7 Demurrage"},
            {"4I7","Day 8 Demurrage"},
            {"4I8","Day 9 Demurrage"},
            {"4I9","Day 10 Demurrage"},
            {"4IV","Vacis Exam Fee"},
            {"4IC","4IC"},
            {"4IE","Container Exam Fee"},
            {"TMF","Traffic Mitigation Fee"},
            {"CTF","Clean Truck Fee"},
            {"HZP","Placard Fee"},
            {"FCH","Flip Fee"},
            {"BBC","Break-bulk Fee"},
            {"DVF","Devanning Fee"},
            {"USD","USDA Fee"},
            {"GEN","Genset Plug_Unplug Fee"},
            {"SCR","Sealing Containers Fee"},
            {"WCR","Weighing Containers Fee"},
            {"GEC","Grounded Export Containers Fee"},
            {"DRC","Drayage of Container Fee"},
            {"ATG","Tallgate Inspection"},
            {"EGF","Export Gate Fee"},
            {"IGF","Import Gate Fee"},
            {"OOG","OOG Flip"},
            {"RF","Rehandling Fee"},
            {"DWT","Extended Dwell Time Fee"},
            {"FI","Fee Indicator Flag"}
        };
    }
}
