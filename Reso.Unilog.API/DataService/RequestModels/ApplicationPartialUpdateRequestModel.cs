using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DataService.RequestModels
{
    public  class ApplicationPartialUpdateRequestModel
    {
        [Required(ErrorMessage = "Required")]
        [JsonProperty("client_id")]
        public  int ClientId { get; set; }
        [Required(ErrorMessage = "Required")]
        [JsonProperty("service_id")]
        public  int ServiceId { get; set; }
    }
}
