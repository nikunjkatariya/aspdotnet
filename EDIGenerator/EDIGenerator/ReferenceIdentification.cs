using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDIGenerator
{
    internal class ReferenceIdentification
    {
        public List<Fees> Fees { get; set; }
        public List<SupportedValues> SupportedValues { get; set; }
/*        public string Qualifier { get; set; } = "";
        public string ReferenceId { get; set; } = "";
        public string Date { get; set; } = "";*/
    }
}
