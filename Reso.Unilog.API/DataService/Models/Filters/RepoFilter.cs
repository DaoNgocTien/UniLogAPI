using Core.DataService.Models.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models.Filters
{
    public class RepoFilter : BaseFilter
    {
        public int server_id { get; set; }
        public int application_id { get; set; }
        //public int? company_id { get; set; }
       public string name { get; set; }
    }
}
