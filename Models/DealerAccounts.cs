using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class DealerAccounts
    {
        public long Id { get; set; }
        public long Memberid { get; set; }
        public long Accountid { get; set; }
        public short State { get; set; }
        public DateTime Modified { get; set; }
    }
}
