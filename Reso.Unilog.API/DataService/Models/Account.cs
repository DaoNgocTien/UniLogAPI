using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class Account
    {
        public Account()
        {
            ManageProject = new HashSet<ManageProject>();
        }

        public int Id { get; set; }
        public int AspNetUserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Role { get; set; }
        public bool? Active { get; set; }

        public virtual AspNetUsers AspNetUser { get; set; }
        public virtual ICollection<ManageProject> ManageProject { get; set; }
    }
}
