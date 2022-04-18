using System.ComponentModel.DataAnnotations;

namespace EDIFileStoreWebApp.Models
{
    public class watchlist
    {
        public int Id { get; set; }
        public string ISA { get; set; }
        public string GS { get; set; }
        public string ST { get; set; }
        public string B4 { get; set; }
        public string SE { get; set; }
        public string GE { get; set; }
        public string IEA { get; set; }

    }
}
