using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class Repo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ServerId { get; set; }
        public int? ApplicationId { get; set; }
        public string RepoUrl { get; set; }
        public string Note { get; set; }
        public bool Active { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }

        public virtual Application Application { get; set; }
        public virtual Server Server { get; set; }
    }
}
