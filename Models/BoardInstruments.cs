using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class BoardInstruments
    {
        public int Id { get; set; }
        public int Boardid { get; set; }
        public int Instrumentid { get; set; }
        public short State { get; set; }
        public DateTime Modified { get; set; }
    }
}
