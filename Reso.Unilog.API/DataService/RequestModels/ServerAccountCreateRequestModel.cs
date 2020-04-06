using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataService.RequestModels.CreateRequestModels
{
    public  class ServerAccountCreateRequestModel : CreateRequestModel
    {
        [Required(ErrorMessage = "Required")]
        [JsonProperty("server_id")]
        public  int ServerId { get; set; }
        [Required(ErrorMessage = "Required")]
        [JsonProperty("username")]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Username Should be minimum 5 and a maximum is 100")]
        public  string Username { get; set; }
        [Required(ErrorMessage = "Required")]        
        [DataType(DataType.Text)]
        [JsonProperty("password")]
        public  string Password { get; set; }
    }
}
