using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class Members
    {
        public int Id { get; set; }
        public short? Type { get; set; }
        public string Code { get; set; }
        public short? State { get; set; }
        public DateTime? Modified { get; set; }
        public long? Partid { get; set; }
        public string Mask { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public bool? Broker { get; set; }
        public bool? Dealer { get; set; }
        public bool? Ander { get; set; }
        public bool? Nominal { get; set; }
        public int? LinkMember { get; set; }
        public string Name { get; set; }
    }
}
