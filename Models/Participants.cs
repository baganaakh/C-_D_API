using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class Participants
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public short? State { get; set; }
        public string Pcity { get; set; }
        public string Pdistr { get; set; }
        public string Phoroo { get; set; }
        public string Pstreet { get; set; }
        public string Pwebpage { get; set; }
        public string Numofemp { get; set; }
        public DateTime? Modified { get; set; }
        public int? Csid { get; set; }
        public int? Webid { get; set; }
        public short? SpecialType { get; set; }
        public short? CompanyType { get; set; }
    }
}
