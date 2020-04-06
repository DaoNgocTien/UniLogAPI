using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace DataService.RequestModels
{
    public  class ApplicationCharacteristicUpdateRequestModel : CreateRequestModel
    {
        [JsonProperty("application_id")]
        [Required(ErrorMessage = "Application Id must be define")]
        public  int ApplicationId { get; set; }

       [JsonProperty("ecf")]
        public  EcfPartialUpadteRequestModel ecf { get; set; }
       [JsonProperty("tcf")]
        public  TcfPartialUpadteRequestModel tcf { get; set; }
       
      
    }
}

