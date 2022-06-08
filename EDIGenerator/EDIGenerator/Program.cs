using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDIGenerator
{
    internal class Program
    {
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

        static void Main(string[] args)
        {
/*            Employee employee = new Employee();
            employee.FirstName = "ASD";
            employee.LastName = "JKL";
            employee.Address = "MLP";
            employee.City = "QAZ";
            employee.SalaryList = new Salary();
            //employee.SalaryList = new List<Salary>() { new Salary { Amount = "123" },new Salary { Amount="234"} };
            employee.SalaryList.Amount = "123";
            employee.SalaryList.paid = true;
            string JSONresult = JsonConvert.SerializeObject(employee);
            string path = @"D:\employee.json";
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(JSONresult.ToString());
                tw.Close();
            }*/
            

            //Variables
            Container container = new Container();
            
            string SenderId="", InterchangeControlNumber="",GroupControlNumber="", TransactionControlNumber="";

            string edipath = @"D:\6555009-O20190215629107.txt";
            string JSONresult;
            string path;
            int Count = 0, CountB=0;
            StreamReader sr = new StreamReader(edipath);
            char[] delimeters = { '~', '\n' };
            string[] edilines = sr.ReadToEnd().ToString().Split(delimeters).Where(p=>!string.IsNullOrWhiteSpace(p)).ToArray();
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
                /*for(int j = 0;j < Statementline.Length;j++)
                {
                    Console.Write(Statementline[j]+" ");
                }
                Console.WriteLine();*/
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
                            Console.WriteLine("Interchange Code is Not Matched!");
                            break;
                        }
                        break;
                    case "GS":
                        if (InterchangeControlNumber != "")
                        {
                            if (Statementline[2] == SenderId)
                            {
                                string[] GERecord = Array.ConvertAll(edilines[edilines.Length - 2].Split('*'), a => a.Trim());
                                if (Statementline[6]== GERecord[2])
                                {
                                    GroupControlNumber = Statementline[6];
                                }
                                else
                                {
                                    Console.WriteLine("Group Records are not Mateched");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Sender Id is Different!");
                                break;
                            }
                        }
                        break;
                    case "ST":
                        if(GroupControlNumber != "")
                        {
                            if (Statementline[1] == "315")
                            {
                                Count++;
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
                                container.Segment.ReleaseDate = GetValue(Statementline, 4);
                                container.Segment.ReleaseTime = GetValue(Statementline, 5);
                                //container.Segment.StatusLocation = Statementline[6];
                                container.Segment.EquipmentInitial = GetValue(Statementline, 7);
                                container.Segment.EquipmentNumber = GetValue(Statementline, 8);
                                container.Segment.EquipmentStatusCode = GetValue(Statementline, 9);
                                container.Segment.EquipmentType = GetValue(Statementline, 10);
                                //container.Segment.LocationIdentifier = Statementline[11];
                                //container.Segment.LocationQualifier = Statementline[12];
                                container.Segment.EquipmentDigit = GetValue(Statementline, 13);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
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
                                    ReferenceId = GetValue(Statementline, 2)
                                });
                            }
                            else
                            {
                                    container.ReferenceIdentification.Fees.Add(new Fees()
                                    {
                                        Code = FeesDic[Statementline[1]],
                                        Amount = GetValue(Statementline, 2),
                                        Date = GetValue(Statementline, 3)
                                    });
                            }
                        }
                        break;
                    case "Q2":
                        if (TransactionControlNumber != "")
                        {
                            try
                            {
                                container.Status.VesselCode = GetValue(Statementline, 1);
                                //container.Status.CountryCode = Statementline[2];
                                //container.Status.DateOne = Statementline[3];
                                //container.Status.DateTwo = Statementline[4];
                                //container.Status.DateThree = Statementline[5];
                                //container.Status.LadingQuantity = Statementline[6];
                                container.Status.Weight = GetValue(Statementline, 7);
                                container.Status.WeightQualifier = GetValue(Statementline, 8);
                                container.Status.FlightNumber = GetValue(Statementline, 9);
                                //container.Status.ReferenceIdQualifier = Statementline[10];
                                //container.Status.ReferenceId = Statementline[11];
                                container.Status.VesselCodeQualifier = GetValue(Statementline, 12);
                                container.Status.VesselName = GetValue(Statementline, 13);
                                //container.Status.Volume = Statementline[14];
                                //container.Status.VolumeUnitQualifier = Statementline[15];
                                container.Status.WeightUnitCode = GetValue(Statementline, 16);
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
                                container.ShipmentStatus.Add(new ShipmentStatus
                                {
                                    ShipmentStatusCode = GetValue(Statementline, 1),
                                    //StatusReasonCode = Statementline[2],
                                    //DispositionCode = Statementline[3],
                                    Date = GetValue(Statementline, 4),
                                    Time = GetValue(Statementline, 5)
                                });
                         }
                        break;
                    case "R4":
                        if (TransactionControlNumber != "")
                        {
                                container.PortOrTerminal.Add(new PortOrTerminal
                                {
                                    FunctionCode = GetValue(Statementline, 1),
                                    LocationQualifier = GetValue(Statementline, 2),
                                    LocationIdentifier = GetValue(Statementline, 3),
                                    PortName = GetValue(Statementline, 4),
                                    CountryCode = GetValue(Statementline, 5),
                                    TerminalName = GetValue(Statementline, 6),
                                    PierName = GetValue(Statementline, 7),
                                    StateCode = GetValue(Statementline, 8)
                                });
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
                                CountB++;
                                JSONresult = JsonConvert.SerializeObject(container);
                                path = @"D:\Status.json";
                                using (var tw = new StreamWriter(path, true))
                                {
                                    tw.WriteLine(JSONresult.ToString());
                                    tw.Close();
                                }
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
                                Console.WriteLine("Transation Code is Not Matched!");
                        }
                        else
                        {
                            Console.WriteLine("Wrong Transaction Format!");
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
            Console.WriteLine(Count+" **"+CountB);
        }
        public static string GetValue(string[] value, int index)
        {
            try
            {
                return value[index];
            }
            catch (IndexOutOfRangeException)
            {
                return "";
            }
        }
    }
}
