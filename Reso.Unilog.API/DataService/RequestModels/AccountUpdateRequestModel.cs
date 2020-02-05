using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.RequestModels
{
    public  class AccountUpdateRequestModel
    {
        [JsonProperty("id")]
        public  int Id { get; set; }
        [JsonProperty("email")]
        public  string Email { get; set; }
        [JsonProperty("address")]
        public  string Address { get; set; }
        [JsonProperty("name")]
        public  string Name { get; set; }
        [JsonProperty("phone")]
        public  string Phone { get; set; }
    }
}
