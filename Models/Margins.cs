using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class Margins
    {
        public long ContractId { get; set; }
        public decimal Buy { get; set; }
        public decimal Sell { get; set; }
        public short Buytype { get; set; }
        public short Selltype { get; set; }
        public DateTime Modified { get; set; }
        public decimal Mbuy { get; set; }
        public decimal Msell { get; set; }
        public long Coid { get; set; }
    }
}
