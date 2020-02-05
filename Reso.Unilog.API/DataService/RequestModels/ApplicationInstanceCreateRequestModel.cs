using DataService.RequestModelss;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace DataService.RequestModels
{
    public  class ApplicationInstanceCreateRequestModel : AppInstanceCreateRequestModel
    {
        [Required(ErrorMessage = "Required")]
        [JsonProperty("system_instance_id")]
        public  int SystemInstanceId { get; set; }
        [Required(ErrorMessage = "Required")]
        [JsonProperty("app_code")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Application Instance Name Should be minimum 5 and a maximum is 200")]
        [DataType(DataType.Text)]
        public  string AppCode { get; set; }
        [Required(ErrorMessage = "Required")]
        [JsonProperty("application_id")]
        public  int AppId { get; set; }
        [Required(ErrorMessage = "Required")]
        [JsonProperty("name")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Application Instance Name Should be minimum 5 and a maximum is 200")]
        [DataType(DataType.Text)]
        public  string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        [JsonProperty("description")]
        [StringLength(300, MinimumLength = 5, ErrorMessage = "Description Name Should be minimum 5 and a maximum is 300")]
        [DataType(DataType.Text)]
        public  string Description { get; set; }

      

    }
}
