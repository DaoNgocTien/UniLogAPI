using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.RequestModels
{
    public  class SystemCreateRequestModel: CreateRequestModel
    {
        [JsonProperty("name")]
        public  string Name { get; set; }
        [JsonProperty("description")]
        public  string Description { get; set; }
        //[JsonProperty("company_id")]
        //public  int CompanyId { get; set; }
    }
}
