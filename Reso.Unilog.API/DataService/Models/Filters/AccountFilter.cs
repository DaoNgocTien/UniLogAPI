using Core.DataService.Models.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models.Filters
{
    public class AccountFilter: BaseFilter
    {
        //public int company_id { get; set; }        
        public string email { get; set; }
        public int role { get; set; }
    }
}
