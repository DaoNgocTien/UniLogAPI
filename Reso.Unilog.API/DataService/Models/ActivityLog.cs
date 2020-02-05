using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class ActivityLog
    {
        public DateTime Time { get; set; }
        public int Id { get; set; }
        public string AppCode { get; set; }
        public string IpAddress { get; set; }
        public string Device { get; set; }
        public string Os { get; set; }
        public string Path { get; set; }
        public string ActionName { get; set; }
        public string Browser { get; set; }
        public string BrowserVersion { get; set; }
        public string Location { get; set; }

        public virtual ApplicationInstance AppCodeNavigation { get; set; }
    }
}
