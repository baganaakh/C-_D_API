using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class Spreads
    {
        public int Id { get; set; }
        public int? Contractid { get; set; }
        public int? Sessionid { get; set; }
        public int? Rspread { get; set; }
        public int? Ispread { get; set; }
        public int? Rparam { get; set; }
        public DateTime? Modified { get; set; }
    }
}
