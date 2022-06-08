using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDIGenerator
{
    internal class ShipmentStatus
    {
        public string ShipmentStatusCode { get; set; } = "";
        //public string StatusReasonCode { get; set; } = "";
        //public string DispositionCode { get; set; } = "";
        public string Date { get; set; } = "";
        public string Time { get; set; } = "";
    }
}
