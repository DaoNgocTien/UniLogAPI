using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class ServerAccount
    {
        public int Id { get; set; }
        public int ServerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Owner { get; set; }
        public string Note { get; set; }
        public bool Active { get; set; }

        public virtual Server Server { get; set; }
    }
}
