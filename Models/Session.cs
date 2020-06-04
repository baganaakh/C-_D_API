using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class Session
    {
        public long Id { get; set; }
        public long? Boardid { get; set; }
        public string Name { get; set; }
        public TimeSpan? Stime { get; set; }
        public TimeSpan? Duration { get; set; }
        public short? Algorithm { get; set; }
        public int? Match { get; set; }
        public short? Allowedtypes { get; set; }
        public string Description { get; set; }
        public short? State { get; set; }
        public DateTime? Modified { get; set; }
        public bool? Isactive { get; set; }
        public DateTime? Starttime { get; set; }
        public DateTime? Endtime { get; set; }
        public string Tduration { get; set; }
        public long? Matched { get; set; }
        public bool? Editorder { get; set; }
        public bool? Delorder { get; set; }
        public short? Markettype { get; set; }
        public bool? Захзээлүүсгэгч { get; set; }
        public bool? Тохиролцсон { get; set; }
        public bool? Кросс { get; set; }
        public bool? Нөхцөлт { get; set; }
        public bool? ЗахЗээлийн { get; set; }
    }
}
