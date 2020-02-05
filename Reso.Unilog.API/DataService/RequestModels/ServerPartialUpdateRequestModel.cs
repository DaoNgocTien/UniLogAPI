
﻿using Newtonsoft.Json;
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
        public  bool Active { get; set; }
    }
}
