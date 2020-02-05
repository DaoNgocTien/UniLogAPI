using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.RequestModels
{
    public  class SystemPartialUpdateRequestModel
    {
        [JsonProperty("id")]
        public  int Id { get; set; }

        [JsonProperty("active")]
        public  bool Active { get; set; }
    }
}
