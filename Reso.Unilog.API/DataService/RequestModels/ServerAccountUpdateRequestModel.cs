using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataService.RequestModels
{
    public  class ServerAccountUpdateRequestModel
    {
        [Required(ErrorMessage = "Required")]
        [JsonProperty("server_id")]
        public int ServerId { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [JsonProperty("username")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Username Should be minimum 5 and a maximum is 100")]
        public  string Username { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [JsonProperty("password")]
        public  string Password { get; set; }
        public readonly bool Active = true;
    }
}
