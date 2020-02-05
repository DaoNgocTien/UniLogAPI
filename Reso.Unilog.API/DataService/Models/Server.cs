using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class Server
    {
        public Server()
        {
            InverseServerMasterNavigation = new HashSet<Server>();
            Repo = new HashSet<Repo>();
            ServerAccount = new HashSet<ServerAccount>();
        }

        public DateTime CreateTime { get; set; }
        public int Id { get; set; }
        public int? ServerMaster { get; set; }
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public string ServerCode { get; set; }
        public int Type { get; set; }
        public int Os { get; set; }
        public string ServerUrl { get; set; }
        public string Description { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public bool? Active { get; set; }
        public DateTime? UpdateTime { get; set; }

        public virtual Server ServerMasterNavigation { get; set; }
        public virtual ServerDetail ServerDetail { get; set; }
        public virtual ICollection<Server> InverseServerMasterNavigation { get; set; }
        public virtual ICollection<Repo> Repo { get; set; }
        public virtual ICollection<ServerAccount> ServerAccount { get; set; }
    }
}
