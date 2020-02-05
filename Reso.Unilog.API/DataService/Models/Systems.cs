using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class Systems
    {
        public Systems()
        {
            Application = new HashSet<Application>();
            ManageProject = new HashSet<ManageProject>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }

        public virtual ICollection<Application> Application { get; set; }
        public virtual ICollection<ManageProject> ManageProject { get; set; }
    }
}
