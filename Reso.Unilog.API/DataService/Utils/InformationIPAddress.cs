using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Model
{
    public  class InformationIPAddress
    {
        [JsonProperty("city")]
        public  string City { get; set; }

        [JsonProperty("country")]
        public  string Country { get; set; }
    }
}
