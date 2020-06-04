using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class Deals
    {
        public long Id { get; set; }
        public short? Boardid { get; set; }
        public string Dealno { get; set; }
        public short? Side { get; set; }
        public long? Memberid { get; set; }
        public long? Accountid { get; set; }
        public long? Assetid { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Price { get; set; }
        public decimal? TotalPrice { get; set; }
        public short? State { get; set; }
        public DateTime? Modified { get; set; }
        public decimal? Fee { get; set; }
        public decimal? M2m { get; set; }
        public decimal? RefPrice { get; set; }
        public short? DealType { get; set; }
        public int? Day { get; set; }
        public decimal? Interests { get; set; }
        public decimal? ToPay { get; set; }
        public string Connect { get; set; }
    }
}
