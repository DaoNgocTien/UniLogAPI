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
	public partial class ActivityLogServiceModel: BaseServiceModel<ActivityLog>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("action_name")]
		public string ActionName { get; set; }
		[JsonProperty("app_code")]
		public string AppCode { get; set; }
		[JsonProperty("browser")]
		public string Browser { get; set; }
		[JsonProperty("browser_version")]
		public string BrowserVersion { get; set; }
		[JsonProperty("device")]
		public string Device { get; set; }
		[JsonProperty("ip_address")]
		public string IpAddress { get; set; }
		[JsonProperty("location")]
		public string Location { get; set; }
		[JsonProperty("os")]
		public string Os { get; set; }
		[JsonProperty("path")]
		public string Path { get; set; }
		[JsonProperty("time")]
		public DateTime Time { get; set; }
		[JsonProperty("app_code_navigation")]
		public ApplicationInstanceServiceModel AppCodeNavigation { get; set; }
		
		public ActivityLogServiceModel(ActivityLog entity) : base(entity)
		{
		}
		
		public ActivityLogServiceModel()
		{
		}
		
	}
	
	public partial class UpdateActivityLogServiceModel: BaseUpdateServiceModel<UpdateActivityLogServiceModel, ActivityLog>
	{
		[JsonProperty("id")]
		public Wrapper<int> Id { get; set; }
		[JsonProperty("action_name")]
		public Wrapper<string> ActionName { get; set; }
		[JsonProperty("app_code")]
		public Wrapper<string> AppCode { get; set; }
		[JsonProperty("browser")]
		public Wrapper<string> Browser { get; set; }
		[JsonProperty("browser_version")]
		public Wrapper<string> BrowserVersion { get; set; }
		[JsonProperty("device")]
		public Wrapper<string> Device { get; set; }
		[JsonProperty("ip_address")]
		public Wrapper<string> IpAddress { get; set; }
		[JsonProperty("location")]
		public Wrapper<string> Location { get; set; }
		[JsonProperty("os")]
		public Wrapper<string> Os { get; set; }
		[JsonProperty("path")]
		public Wrapper<string> Path { get; set; }
		[JsonProperty("time")]
		public Wrapper<DateTime> Time { get; set; }
		[JsonProperty("app_code_navigation")]
		public ApplicationInstanceServiceModel AppCodeNavigation { get; set; }
		
	}
}
