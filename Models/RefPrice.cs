using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class RefPrice
    {
        public long ContractId { get; set; }
        public decimal? Refprice1 { get; set; }
        public DateTime? Modified { get; set; }
        public string Name { get; set; }
    }
}
