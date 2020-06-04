using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class Order
    {
        public long Id { get; set; }
        public long? BoardId { get; set; }
        public short? Side { get; set; }
        public long? Memberid { get; set; }
        public long? Accountid { get; set; }
        public long? Assetid { get; set; }
        public int? Qty { get; set; }
        public decimal? Price { get; set; }
        public short? State { get; set; }
        public DateTime Modified { get; set; }
        public short? DealType { get; set; }
        public string Connect { get; set; }
        public int? Day { get; set; }
        public decimal? TotSum { get; set; }
        public decimal? ToPay { get; set; }
        public decimal? Interests { get; set; }
        public decimal? Fee { get; set; }
        public long? Assetid2 { get; set; }
        public int? Qty2 { get; set; }
        public decimal? Price2 { get; set; }
    }
}
