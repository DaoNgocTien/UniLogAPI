using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DataService.RequestModels
{
    public  class LogErrorCreateRequestModel: CreateRequestModel
    {                
        [JsonProperty("app_code")]
        public  string AppCode { get; set; }
        [JsonProperty("serverity")]
        public  int Serverity { get; set; }
        [JsonProperty("exception")]
        public  Exception Exception { get; set; }
    }

    public  class LogCreateRequestModel: LogErrorCreateRequestModel
    {

        [JsonProperty("log_type")]
        public  int LogType { get; set; }
        [JsonProperty("error_code_id")]
        public  int? ErrorCodeId { get; set; }
        [JsonProperty("file_name")]
        public  string FileName { get; set; }
        [JsonProperty("line_code")]
        public  int LineCode { get; set; }
        [JsonProperty("log_date")]
        public  DateTime LogDate { get; set ; } = DateTime.UtcNow.AddHours(7);
        [JsonProperty("message")]
        public  string Message { get; set; }
        [JsonProperty("project_name")]
        public  string ProjectName { get; set; }
    }
}
