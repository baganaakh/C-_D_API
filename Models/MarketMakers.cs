using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class MarketMakers
    {
        public int Id { get; set; }
        public int Contactid { get; set; }
        public int Memberid { get; set; }
        public long Accountid { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public int Ticks { get; set; }
        public string Description { get; set; }
        public int Orderlimit { get; set; }
        public short State { get; set; }
        public DateTime Modified { get; set; }
    }
}
