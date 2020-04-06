using Core.DataService.Models.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models.Filters
{
    public class AccountFilter: BaseFilter
    { 
        public string email { get; set; }
        public int role { get; set; }
    }
}
