﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.RequestModels
{
    public  class LogPartialUpdateRequestModel
    {
        [JsonProperty("id")]
        public  int Id { get; set; }
    }
}
