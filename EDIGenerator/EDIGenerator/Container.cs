using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDIGenerator
{
    internal class Container
    {
        public string ContainerId { get; set; }
        public Segment Segment { get; set; } // B4
        public ReferenceIdentification ReferenceIdentification { get; set; } //N9
        public Status Status { get; set; }//Q2
        public List<ShipmentStatus> ShipmentStatus { get; set; }//SG
        public List<PortOrTerminal> PortOrTerminal { get; set; }//R4
        //public DTReference DTReference { get; set; }//DTM
    }
}
