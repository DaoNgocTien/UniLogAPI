using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataService.RequestModels
{
    public  class ApplicationInstancePartialUpdateRequestModel
    {
        [Required(ErrorMessage = "Required")]
        [JsonProperty("id")]
        public  int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(200, MinimumLength = 0,ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [DataType(DataType.Text)]
        [JsonProperty("app_code")]
        public  string AppCode { get; set; }
        public  readonly DateTime UpdateTime = DateTime.UtcNow.AddHours(7);
    }
}
