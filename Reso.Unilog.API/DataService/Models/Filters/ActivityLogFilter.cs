using Core.DataService.Models.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models.Filters
{
    public class ActivityLogFilter : BaseFilter
    {
        public DateTime? start_time { get; set; }
        public DateTime? end_time { get; set; }
        public string app_code { get; set; }
    }
}
