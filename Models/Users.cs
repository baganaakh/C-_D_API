using System;
using System.Collections.Generic;

namespace AdminAPI2.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Uname { get; set; }
        public string Password { get; set; }
        public DateTime? Modified { get; set; }
        public string Role { get; set; }
        public int? MemId { get; set; }
        public string Serverip { get; set; }
        public string ServerDatabase { get; set; }
        public string ServerUname { get; set; }
        public string ServerPassword { get; set; }
    }
}
