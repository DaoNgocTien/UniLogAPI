using Core.DataService.Models.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataService.Models.Filters
{
    public class ServerAccountFilter : BaseFilter
    {
        public int server_id { get; set; }
      
        public string username { get; set; }

    }
}
