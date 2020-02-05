using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class ApplicationRelation
    {
        public int? ClientId { get; set; }
        public int? ServiceId { get; set; }
        public int Id { get; set; }

        public virtual Application Client { get; set; }
        public virtual Application Service { get; set; }
    }
}
