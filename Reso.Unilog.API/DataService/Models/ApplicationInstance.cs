using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class ApplicationInstance
    {
        public ApplicationInstance()
        {
            ActivityLog = new HashSet<ActivityLog>();
            Log = new HashSet<Log>();
            ManageProject = new HashSet<ManageProject>();
        }

        public DateTime? UpdateTime { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int AppId { get; set; }
        public string AppCode { get; set; }
        public string Description { get; set; }
        public double? ApplicationVersion { get; set; }
        public string ReleaseUrl { get; set; }
        public string ConfigUrl { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreateTime { get; set; }

        public virtual Application App { get; set; }
        public virtual ICollection<ActivityLog> ActivityLog { get; set; }
        public virtual ICollection<Log> Log { get; set; }
        public virtual ICollection<ManageProject> ManageProject { get; set; }
    }
}
