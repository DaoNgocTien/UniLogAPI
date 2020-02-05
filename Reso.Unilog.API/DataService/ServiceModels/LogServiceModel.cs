using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.Global;
using DataService.Models;
using Newtonsoft.Json;

namespace DataService.ServiceModels
{
	public partial class LogServiceModel: BaseServiceModel<Log>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("active")]
		public bool? Active { get; set; }
		[JsonProperty("app_code")]
		public string AppCode { get; set; }
		[JsonProperty("error_code_id")]
		public int? ErrorCodeId { get; set; }
		[JsonProperty("file_name")]
		public string FileName { get; set; }
		[JsonProperty("line_code")]
		public int LineCode { get; set; }
		[JsonProperty("log_date")]
		public DateTime LogDate { get; set; }
		[JsonProperty("log_type")]
		public int LogType { get; set; }
		[JsonProperty("message")]
		public string Message { get; set; }
		[JsonProperty("project_name")]
		public string ProjectName { get; set; }
		[JsonProperty("serverity")]
		public int Serverity { get; set; }
		[JsonProperty("app_code_navigation")]
		public ApplicationInstanceServiceModel AppCodeNavigation { get; set; }
		[JsonProperty("error_code")]
		public ErrorCodeServiceModel ErrorCode { get; set; }
		
		public LogServiceModel(Log entity) : base(entity)
		{
		}
		
		public LogServiceModel()
		{
		}
		
	}
	
	public partial class UpdateLogServiceModel: BaseUpdateServiceModel<UpdateLogServiceModel, Log>
	{
		[JsonProperty("id")]
		public Wrapper<int> Id { get; set; }
		[JsonProperty("active")]
		public Wrapper<bool?> Active { get; set; }
		[JsonProperty("app_code")]
		public Wrapper<string> AppCode { get; set; }
		[JsonProperty("error_code_id")]
		public Wrapper<int?> ErrorCodeId { get; set; }
		[JsonProperty("file_name")]
		public Wrapper<string> FileName { get; set; }
		[JsonProperty("line_code")]
		public Wrapper<int> LineCode { get; set; }
		[JsonProperty("log_date")]
		public Wrapper<DateTime> LogDate { get; set; }
		[JsonProperty("log_type")]
		public Wrapper<int> LogType { get; set; }
		[JsonProperty("message")]
		public Wrapper<string> Message { get; set; }
		[JsonProperty("project_name")]
		public Wrapper<string> ProjectName { get; set; }
		[JsonProperty("serverity")]
		public Wrapper<int> Serverity { get; set; }
		[JsonProperty("app_code_navigation")]
		public ApplicationInstanceServiceModel AppCodeNavigation { get; set; }
		[JsonProperty("error_code")]
		public ErrorCodeServiceModel ErrorCode { get; set; }
		
	}
}
