using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class ActiveSessions
    {
        public int Id { get; set; }
        public int Sessionid { get; set; }
        public short Isactive { get; set; }
        public TimeSpan Starttime { get; set; }
        public TimeSpan Endtime { get; set; }
        public TimeSpan Tduration { get; set; }
        public int Matched { get; set; }
        public short State { get; set; }
    }
}
