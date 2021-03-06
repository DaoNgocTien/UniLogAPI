﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataService.RequestModels.CreateRequestModels
{
     public  class RepoCreateRequestModel : CreateRequestModel
    {
        [Required(ErrorMessage = "Required")]
        [JsonProperty("name")]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Name Should be minimum 5 and a maximum is 100")]
        public  string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        [JsonProperty("server_id")]
        public  int ServerId { get; set; }

        [JsonProperty("application_id")]
        public  int? ApplicationId { get; set; }

        [Required(ErrorMessage = "Required")]
        [JsonProperty("repo_url")]
        public  string RepoUrl { get; set; }

        [DataType(DataType.Text)]
        [JsonProperty("note")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Note Should be minimum 5 and a maximum is 200")]
        public  string Note { get; set; }
    }
}
