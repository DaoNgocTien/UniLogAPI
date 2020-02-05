
﻿using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataService.RequestModels
{
    public  class ServerCreateRequestModel : CreateRequestModel
    {
        //[Required(ErrorMessage = "Required")]
        //[JsonProperty("company_id")]
        //public  int CompanyId { get; set; }
        [JsonProperty("server_master")]
        
        public  int? ServerMaster { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Server Name Should be minimum 5 and a maximum is 200")]
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

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Url)]
        [JsonProperty("server_url")]        
        public  string ServerUrl { get; set; }

        //[Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [JsonProperty("description")]
        public  string Description { get; set; }

        [JsonProperty("expired_date")]
        public  DateTime? ExpiredDate { get; set; }

        [JsonProperty("server_code")]
        [Required(ErrorMessage = "Required")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Server Code Should be minimum 1 and a maximum is 10")]
        [DataType(DataType.Text)]
        public  string ServerCode { get; set; }

        [JsonProperty("server_detail")]
        public ServerDetailCreateRequestModel ServerDetail { get; set; }

    }
}
