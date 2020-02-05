
﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataService.RequestModels
{
    public  class ServerUpdateRequestModel
    {
        [Required(ErrorMessage = "Required")]
        [JsonProperty("id")]
        public  int Id { get; set; }
        [JsonProperty("server_master")]
        [Range(1, 4, ErrorMessage = "Server Master should be between 1 and 3")]
        public  int? ServerMaster { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Application Name Should be minimum 5 and a maximum is 200")]
        [DataType(DataType.Text)]
        [JsonProperty("name")]
        public  string Name { get; set; }
        [JsonProperty("ip_address")]
        public  string IpAddress { get; set; }

        [Range(1, 4, ErrorMessage = "Server Type should be between 1 and 3")]
        [JsonProperty("type")]
        public  int Type { get; set; }

        [Range(1, 10, ErrorMessage = "Server Os should be between 1 and 10")]
        [JsonProperty("os")]
        public  int Os { get; set; }

        [DataType(DataType.Url)]
        [JsonProperty("server_url")]
        public  string ServerUrl { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [JsonProperty("description")]
        public  string Description { get; set; }

        [JsonProperty("expire_date")]
        public  DateTime? ExpiredDate { get; set; }
        [JsonIgnore]
        public  readonly DateTime? UpdateTime = DateTime.UtcNow.AddHours(7);
        [JsonProperty("server_code")]
        public  string ServerCode { get; set; }

        [JsonProperty("server_detail")]

        public  ServerDetailUpdateRequestModel ServerDetail { get; set; }
       
    }
}
