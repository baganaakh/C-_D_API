using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class InvoiceDetails
    {
        public long Id { get; set; }
        public long? Invoiceid { get; set; }
        public int? Assetid { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Price { get; set; }
        public short? State { get; set; }
        public DateTime? Modified { get; set; }
        public string Note { get; set; }
        public long? DealNo { get; set; }
    }
}
