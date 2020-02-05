using Core.DataService.Models.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models.Filters
{
    public class ApplicationInstanceFilter : BaseFilter
    {
       // public int company_id { get; set; }
        public int application_id { get; set; }
        public string app_code { get; set; }
        public int account_id { get; set; }
        public int server_id { get; set; }

      
    }
}
