using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class ApplicationCharacteristic
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public int? ActualEfford { get; set; }
        public bool Active { get; set; }

        public virtual Application Application { get; set; }
    }
}
