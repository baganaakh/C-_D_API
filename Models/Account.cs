using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class Account
    {
        public long Id { get; set; }
        public long? Memberid { get; set; }
        public string AccNumber { get; set; }
        public short? AccountType { get; set; }
        public long? LinkAccount { get; set; }
        public DateTime? Modified { get; set; }
        public string Mask { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public short? State { get; set; }
    }
}
