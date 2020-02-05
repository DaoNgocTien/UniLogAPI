using Core.DataService.Models.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models.Filters
{
    public class ServerFilter : BaseFilter
    {
        //public int company_id { get; set; }
        public string server_code { get; set; }
        public int type { get; set; }
        public int os { get; set; }
        public int server_master { get; set; }
    }
}
