using Core.DataService.Models.Filters;
using DataService.Model.RequestModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataService.Models.Filters
{
    public class ApplicationFilter : BaseFilter
    {
     
        public int system_id { get; set; }

        public string application_name { get; set; }

        //[Range(1, 3, ErrorMessage = "Category should be between 1 and 3")]
        //[DataType(DataType.Text)]
        public int category { get; set; }

        [StringRange(AllowableValues = new[] { null, "I", "U", "S2B" }, ErrorMessage = "Type should be N, C or E")]
        [DataType(DataType.Text)]
        public string origin { get; set; }

        [StringRange(AllowableValues = new[] { null, "N", "C", "E" }, ErrorMessage = "Type should be N, C or E")]
        [DataType(DataType.Text)]
        public string type { get; set; }

       // [Range(1, 3, ErrorMessage = "Stage should be between 1 and 3")]
       //   [DataType(DataType.Text)]
        public int stage { get; set; }
        public bool is_done { get; set; }

      
    }
}
