using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class Boards
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public short Type { get; set; }
        public string Tdays { get; set; }
        public short State { get; set; }
        public DateTime Modified { get; set; }
        public string Description { get; set; }
        public short? DealType { get; set; }
        public TimeSpan? ExpTime { get; set; }
        public short? ExpDate { get; set; }
    }
}
