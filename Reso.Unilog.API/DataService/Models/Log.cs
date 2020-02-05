using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class Log
    {
        public int Id { get; set; }
        public DateTime LogDate { get; set; }
        public string Message { get; set; }
        public string AppCode { get; set; }
        public string ProjectName { get; set; }
        public string FileName { get; set; }
        public int LineCode { get; set; }
        public int Serverity { get; set; }
        public int LogType { get; set; }
        public int? ErrorCodeId { get; set; }
        public bool? Active { get; set; }

        public virtual ApplicationInstance AppCodeNavigation { get; set; }
        public virtual ErrorCode ErrorCode { get; set; }
    }
}
