using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class ClearingAccounts
    {
        public int Id { get; set; }
        public int? Memberid { get; set; }
        public string Account { get; set; }
        public short? Type { get; set; }
        public int? Currency { get; set; }
        public decimal? Blnc { get; set; }
        public decimal? Sblnc { get; set; }
        public long? Linkaccount { get; set; }
        public short? State { get; set; }
        public DateTime? Modified { get; set; }
    }
}
