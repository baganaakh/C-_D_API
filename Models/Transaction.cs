using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class Transaction
    {
        public long Id { get; set; }
        public long? AccountId { get; set; }
        public short? Type { get; set; }
        public short? Type1 { get; set; }
        public int? Amount { get; set; }
        public int? AssetId { get; set; }
        public int? Rate { get; set; }
        public string Note { get; set; }
        public DateTime? Tdate { get; set; }
        public short? State { get; set; }
        public DateTime? Modified { get; set; }
        public long? UserId { get; set; }
        public int? Memberid { get; set; }
        public string Currency { get; set; }
    }
}
