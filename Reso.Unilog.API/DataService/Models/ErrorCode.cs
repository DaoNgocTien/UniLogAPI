using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class ErrorCode
    {
        public ErrorCode()
        {
            Log = new HashSet<Log>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Log> Log { get; set; }
    }
}
