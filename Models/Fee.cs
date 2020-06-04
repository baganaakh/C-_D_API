using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class Fee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Value { get; set; }
        public DateTime? Modified { get; set; }
    }
}
