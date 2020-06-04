using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class UserAccounts
    {
        public long Id { get; set; }
        public long Userid { get; set; }
        public long Accountid { get; set; }
        public short State { get; set; }
        public DateTime Modified { get; set; }
    }
}
