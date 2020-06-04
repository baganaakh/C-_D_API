using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class Contracts
    {
        public long Id { get; set; }
        public long? SecurityId { get; set; }
        public short? Type { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal? Lot { get; set; }
        public int? TickTable { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public short? GroupId { get; set; }
        public short? State { get; set; }
        public DateTime? Modified { get; set; }
        public int? MmorderLimit { get; set; }
        public int? OrderLimit { get; set; }
        public decimal? RefpriceParam { get; set; }
        public long? Bid { get; set; }
    }
}
