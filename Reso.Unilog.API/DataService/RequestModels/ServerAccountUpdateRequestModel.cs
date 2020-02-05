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
        [JsonProperty("id")]
        public  int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [JsonProperty("username")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Username Should be minimum 5 and a maximum is 100")]
        public  string Username { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [JsonProperty("password")]
        public  string Password { get; set; }
        [Required(ErrorMessage = "Required")]
        [JsonProperty("owner")]
        [DataType(DataType.Text)]
        public  string Owner { get; set; }
        [JsonProperty("note")]
        public  string Note { get; set; }
        [JsonProperty("active")]
        public  bool Active { get; set; }
    }
}
