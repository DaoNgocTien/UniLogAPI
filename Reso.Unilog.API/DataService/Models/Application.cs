using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class Application
    {
        public Application()
        {
            ApplicationInstance = new HashSet<ApplicationInstance>();
            ApplicationRelationClient = new HashSet<ApplicationRelation>();
            ApplicationRelationService = new HashSet<ApplicationRelation>();
            ManageProject = new HashSet<ManageProject>();
            Repo = new HashSet<Repo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? SystemsId { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public int Category { get; set; }
        public int? Stage { get; set; }
        public int? Efford { get; set; }
        public string Origin { get; set; }
        public int? Team { get; set; }
        public string Type { get; set; }
        public string Technologies { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public string SourceCodeUrl { get; set; }
        public bool? IsDone { get; set; }
        public bool Active { get; set; }

        public virtual Systems Systems { get; set; }
        public virtual ApplicationCharacteristic ApplicationCharacteristic { get; set; }
        public virtual ICollection<ApplicationInstance> ApplicationInstance { get; set; }
        public virtual ICollection<ApplicationRelation> ApplicationRelationClient { get; set; }
        public virtual ICollection<ApplicationRelation> ApplicationRelationService { get; set; }
        public virtual ICollection<ManageProject> ManageProject { get; set; }
        public virtual ICollection<Repo> Repo { get; set; }
    }
}
