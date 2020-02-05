using DataService.Model.RequestModel;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataService.RequestModels
{
    public  class ApplicationCreateRequestModel : AppCreateRequestModel
    {
        [Required(ErrorMessage = "Required")]
        [JsonProperty("system_id")]
        public  int SystemsId { get; set; }
        [Required(ErrorMessage = "Required")]
        [JsonProperty("start_date")]
        public  DateTime StartDate { get; set; }
        [JsonProperty("end_date")]
        public  DateTime? EndDate { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Application Name Should be minimum 5 and a maximum is 200")]
        [DataType(DataType.Text)]
        [JsonProperty("name")]
        public  string Name { get; set; }
        [JsonProperty("team")]
        public  int? Team { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [JsonProperty("description")]
        public  string Description { get; set; }

        [JsonProperty("note")]
        public  string Note { get; set; }

        [Required(ErrorMessage = "Required")]
        [JsonProperty("category")]
        [Range(1, 5, ErrorMessage = "Category should be between 1 and 5")]
        public  int Category { get; set; }
        [DataType(DataType.Url)]
        [JsonProperty("link")]
        public  string Link { get; set; }
        [DataType(DataType.Url)]
        [JsonProperty("source_code_url")]
        public  string SourceCodeUrl { get; set; }

        [Required(ErrorMessage = "Required")]
        [JsonProperty("stage")]
        [Range(1, 3, ErrorMessage = "Stage should be between 1 and 3")]
        public  int? Stage { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringRange(AllowableValues = new[] { "I", "U", "S2B" }, ErrorMessage = "Type should be N, C or E")]
        [DataType(DataType.Text)]
        [JsonProperty("origin")]
        public  string Origin { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringRange(AllowableValues = new[] { "N", "C", "E" }, ErrorMessage = "Type should be N, C or E")]
        [DataType(DataType.Text)]
        [JsonProperty("type")]
        public  string Type { get; set; }

        [Required(ErrorMessage = "Required")]
        [JsonProperty("technologies")]
        [DataType(DataType.Text)]
        public  string Technologies { get; set; }

        [Required(ErrorMessage = "Required")]
        [Range(1, 4, ErrorMessage = "Priority should be between 1 and 4")]
        [JsonProperty("priority")]
        public  int Priority { get; set; }

        [Required(ErrorMessage = "Required")]
        [Range(1, 3, ErrorMessage = "Status should be between 1 and 5")]
        [JsonProperty("status")]
        public  int Status { get; set; }
        [JsonProperty("is_service")]
        public  bool? IsService { get; set; }
    }
}
