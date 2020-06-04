using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class AccountDetails
    {
        public int Id { get; set; }
        public decimal? FreezeValue { get; set; }
        public decimal? Amount { get; set; }
        public int? AssetId { get; set; }
        public long? AccountId { get; set; }
    }
}
