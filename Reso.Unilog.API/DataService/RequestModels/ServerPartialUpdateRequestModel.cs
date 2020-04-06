
using DataService.ServiceModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataService.RequestModels
{
    public  class ServerPartialUpdateRequestModel
    {
        [Required(ErrorMessage = "Required")]

        [JsonProperty("id")]
        public  int Id { get; set; }
        [JsonProperty("active")]
        public bool Active { get; set; }
        [JsonProperty("change_status")]
        public bool ChangeStatus { get; set; }
        [JsonProperty("server_detail")]
        public ServerDetailUpdateRequestModel ServerDetail { get; set; }

    }
}
