using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class Invoices
    {
        public long Id { get; set; }
        public long? Boardid { get; set; }
        public long? Dealno { get; set; }
        public short? Side { get; set; }
        public long? Accountid { get; set; }
        public long? Assetid { get; set; }
        public short? DealType { get; set; }
        public decimal? Qty { get; set; }
        public decimal? TotalPrice { get; set; }
        public short? State { get; set; }
        public decimal? Fee { get; set; }
        public DateTime? Modified { get; set; }
        public DateTime Invoiceno { get; set; }
        public DateTime? Invoicedate { get; set; }
        public DateTime? Expiredate { get; set; }
        public TimeSpan? Expiretime { get; set; }
    }
}
