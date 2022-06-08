using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDIGenerator
{
    internal class PortOrTerminal
    {
        public string FunctionCode { get; set; } = "";
        public string LocationQualifier { get; set; } = "";
        public string LocationIdentifier { get; set; } = "";
        public string PortName { get; set; } = "";
        public string CountryCode { get; set; } = "";
        public string TerminalName { get; set; } = "";
        public string PierName { get; set; } = "";
        public string StateCode { get; set; } = "";
    }
}
