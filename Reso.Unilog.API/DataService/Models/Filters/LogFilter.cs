using Core.DataService.Models.Filters;
using System;

namespace DataService.Models.Filters
{
    public class LogFilter : BaseFilter
    {
        public DateTime? start_time { get; set; }
        public DateTime? end_time { get; set; }
        public string app_code { get; set; }
        public int? serverity { get; set; }
    }
}
