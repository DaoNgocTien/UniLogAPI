using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataService.RequestModels
{
    public  class ApplicationCharacteristicCreateRequestModel: CreateRequestModel
    {
        [JsonProperty("application_id")]
        public  int ApplicationId { get; set; }

        [JsonProperty("actual_efford")]
        public  int? ActualEfford { get; set; }

        
    }
}
