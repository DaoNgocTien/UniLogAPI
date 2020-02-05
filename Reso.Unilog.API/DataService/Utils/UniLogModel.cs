using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Model
{
    public  class UniLogModel
    {
        [JsonProperty("Key")]
        public  string Key { get; set; }
        [JsonProperty("IV")]
        public  string IV { get; set; }
        [JsonProperty("UniLogToken")]
        public  string UniLogToken { get; set; }
    }
}
