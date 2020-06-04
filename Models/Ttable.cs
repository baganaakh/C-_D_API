using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class Ttable
    {
        public long Id { get; set; }
        public decimal? ArrangePrice { get; set; }
        public decimal? TickSize { get; set; }
        public long? Userid { get; set; }
        public long? Assetid { get; set; }
        public DateTime? Modified { get; set; }
        public string Name { get; set; }
    }
}
