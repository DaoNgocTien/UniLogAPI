using Core.DataService.Models.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models.Filters
{
    public class ApplicationCharacteristicFilter : BaseFilter
    {
        public int application_id { get; set; }
    }
}
