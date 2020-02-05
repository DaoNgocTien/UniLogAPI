using Newtonsoft.Json;
using System;

namespace Core.DataService.Models.Filters
{
    public class BaseFilter
    {
        [JsonProperty("ids")]
        public string ids { get; set; }
        [JsonProperty("limit")]
        public int limit { get; set; }
        [JsonProperty("since_id")]
        public int since_id { get; set; }
        [JsonProperty("create_at_min")]
        public DateTime create_at_min { get; set; }
        [JsonProperty("create_at_max")]
        public DateTime create_at_max { get; set; }

        /// <summary>
        /// List of request column
        /// Service Layer not handle this request
        /// Client of service take all fields of objects
        /// Using for client call api or controller
        /// </summary>
        /// 
        [JsonProperty("fields")]
        public string fields { get; set; }
        [JsonProperty("ref_fields")]
        public string ref_fields { get; set; }
    }
}
