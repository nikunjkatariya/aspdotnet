using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDIGenerator
{
    internal class DTReference
    {
        public string Qualifier { get; set; } = "";
        public string Date { get; set; } = "";
        public string Time { get; set; } = "";
        public string TimeCode { get; set; } = "";
        public string PeriodFormatQualifier { get; set; } = "";
        public string DTPeriod { get; set; } = "";
    }
}
