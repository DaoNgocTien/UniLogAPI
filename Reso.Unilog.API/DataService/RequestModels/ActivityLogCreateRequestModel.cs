using DataService.RequestModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
namespace DataService.RequestModels
{
    public  class ActivityLogCreateRequestModel : CreateRequestModel
    {
        [JsonProperty("time")]
        public  DateTime Time { get; set; }
        [JsonProperty("application_code")]
        public  string AppCode { get; set; }
        [JsonProperty("ip_address")]
        public  string IpAddress { get; set; }
        [JsonProperty("device")]
        public  string Device { get; set; }
        [JsonProperty("os")]
        public  string Os { get; set; }
        [JsonProperty("path")]
        public  string Path { get; set; }
        [JsonProperty("action_name")]
        public  string ActionName { get; set; }
        [JsonProperty("browser")]
        public  string Browser { get; set; }
        [JsonProperty("browser_version")]
        public  string BrowserVersion { get; set; }
        [JsonProperty("location")]
        public  string Location { get; set; }
    }
}
