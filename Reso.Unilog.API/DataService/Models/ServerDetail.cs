using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class ServerDetail
    {
        public int Id { get; set; }
        public int ServerId { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string Disk1 { get; set; }
        public string VolumeDisk1 { get; set; }
        public string Disk2 { get; set; }
        public string VolumeDisk2 { get; set; }
        public string Disk3 { get; set; }
        public string VolumeDisk3 { get; set; }
        public bool Active { get; set; }

        public virtual Server Server { get; set; }
    }
}
