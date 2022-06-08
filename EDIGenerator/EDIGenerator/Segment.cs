using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDIGenerator
{
    internal class Segment
    {
        public string Code { get; set; } = "";
        //public string InquiryRequestNumber { get; set; } = "";
        public string ShipmentStatusCode { get; set; } = "";
        public string ReleaseDate { get; set; } = "";
        public string ReleaseTime { get; set; } = "";
        //public string StatusLocation { get; set; } = "";
        public string EquipmentInitial { get; set; }="";
        public string EquipmentNumber { get; set; }="";
        public string EquipmentStatusCode { get; set; }="";
        public string EquipmentType { get; set; }="";
        //public string LocationIdentifier { get; set; }="";
        //public string LocationQualifier { get; set; }="";
        public string EquipmentDigit { get; set; }="";
    }
}
