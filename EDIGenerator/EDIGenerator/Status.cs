using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDIGenerator
{
    internal class Status
    {
        public string VesselCode { get; set; }="";
        //public string CountryCode { get; set; }="";
        //public string DateOne { get; set; }="";
        //public string DateTwo { get; set; }="";
        //public string DateThree { get; set; }="";
        //public string LadingQuantity { get; set; }="";
        public string Weight { get; set; }="";
        public string WeightQualifier { get; set; }="";
        public string FlightNumber { get; set; }="";
        //public string ReferenceIdQualifier { get; set; }="";
        //public string ReferenceId { get; set; }="";
        public string VesselCodeQualifier { get; set; }="";
        public string VesselName { get; set; }="";
        //public string Volume { get; set; }="";
        //public string VolumeUnitQualifier { get; set; }="";
        public string WeightUnitCode { get; set; }="";
    }
}
