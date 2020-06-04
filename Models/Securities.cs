using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class Securities
    {
        public int Id { get; set; }
        public int? Partid { get; set; }
        public short? Type { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? TotalQty { get; set; }
        public decimal? FirstPrice { get; set; }
        public decimal? IntRate { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public short? State { get; set; }
        public DateTime? Modified { get; set; }
        public int? AssetId { get; set; }
    }
}
