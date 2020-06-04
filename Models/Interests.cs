using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class Interests
    {
        public int Id { get; set; }
        public decimal? Interest { get; set; }
        public int? Assetid { get; set; }
        public decimal? RepoInterset { get; set; }
        public decimal? LoanInterset { get; set; }
        public decimal? MaxValue { get; set; }
        public decimal? MinValue { get; set; }
    }
}
