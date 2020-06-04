using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class Assets
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public long Volume { get; set; }
        public string Note { get; set; }
        public DateTime ExpireDate { get; set; }
        public short State { get; set; }
        public DateTime Modified { get; set; }
        public decimal Ratio { get; set; }
        public decimal? Price { get; set; }
    }
}
