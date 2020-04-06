using Core.DataService.Models.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models.Filters
{
    public class SystemFilter : BaseFilter
    {
        public int company_id { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
    }
}
