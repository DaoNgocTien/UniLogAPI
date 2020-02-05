using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataService.RequestModels
{
    public  class ApplicationInstanceUpdateRequestModel
    {

        [Required(ErrorMessage = "Required")]
        [JsonProperty("id")]
        public  int Id { get; set; }
        [JsonProperty("application_version")]
        public  double? ApplicationVersion { get; set; }
        [JsonProperty("config_url")]
        //[RegularExpression(@"^.{5,}$", ErrorMessage = "Minimum 3 characters required")]
        //[Required(ErrorMessage = "Required")]
        [StringLength(200, MinimumLength = 0, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [DataType(DataType.Text)]
        public  string ConfigUrl { get; set; }        
        [JsonProperty("description")]
        [StringLength(300, MinimumLength = 0, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [DataType(DataType.Text)]
        public  string Description { get; set; }
        [Required(ErrorMessage = "Required")]
        [JsonProperty("name")]
        [StringLength(200, MinimumLength = 0, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [DataType(DataType.Text)]
        public  string Name { get; set; }
        [JsonProperty("release_url")]
        [StringLength(200, MinimumLength = 0, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [DataType(DataType.Text)]
        public  string ReleaseUrl { get; set; }

        public  readonly DateTime UpdateTime = DateTime.UtcNow.AddHours(7);
    }
}
