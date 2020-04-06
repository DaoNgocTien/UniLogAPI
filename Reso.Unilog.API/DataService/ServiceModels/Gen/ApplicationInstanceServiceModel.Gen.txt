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
	public partial class ApplicationInstanceServiceModel: BaseServiceModel<ApplicationInstance>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("active")]
		public bool? Active { get; set; }
		[JsonProperty("app_code")]
		public string AppCode { get; set; }
		[JsonProperty("app_id")]
		public int AppId { get; set; }
		[JsonProperty("application_version")]
		public double? ApplicationVersion { get; set; }
		[JsonProperty("config_url")]
		public string ConfigUrl { get; set; }
		[JsonProperty("create_time")]
		public DateTime? CreateTime { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("release_url")]
		public string ReleaseUrl { get; set; }
		[JsonProperty("update_time")]
		public DateTime? UpdateTime { get; set; }
		[JsonProperty("app")]
		public ApplicationServiceModel App { get; set; }
		[JsonProperty("log")]
		public IEnumerable<LogServiceModel> Log { get; set; }
		[JsonProperty("manage_project")]
		public IEnumerable<ManageProjectServiceModel> ManageProject { get; set; }
		
		public ApplicationInstanceServiceModel(ApplicationInstance entity) : base(entity)
		{
		}
		
		public ApplicationInstanceServiceModel()
		{
		}
		
	}
	
	public partial class UpdateApplicationInstanceServiceModel: BaseUpdateServiceModel<UpdateApplicationInstanceServiceModel, ApplicationInstance>
	{
		[JsonProperty("id")]
		public Wrapper<int> Id { get; set; }
		[JsonProperty("active")]
		public Wrapper<bool?> Active { get; set; }
		[JsonProperty("app_code")]
		public Wrapper<string> AppCode { get; set; }
		[JsonProperty("app_id")]
		public Wrapper<int> AppId { get; set; }
		[JsonProperty("application_version")]
		public Wrapper<double?> ApplicationVersion { get; set; }
		[JsonProperty("config_url")]
		public Wrapper<string> ConfigUrl { get; set; }
		[JsonProperty("create_time")]
		public Wrapper<DateTime?> CreateTime { get; set; }
		[JsonProperty("description")]
		public Wrapper<string> Description { get; set; }
		[JsonProperty("name")]
		public Wrapper<string> Name { get; set; }
		[JsonProperty("release_url")]
		public Wrapper<string> ReleaseUrl { get; set; }
		[JsonProperty("update_time")]
		public Wrapper<DateTime?> UpdateTime { get; set; }
		[JsonProperty("app")]
		public ApplicationServiceModel App { get; set; }
		[JsonProperty("log")]
		public IEnumerable<LogServiceModel> Log { get; set; }
		[JsonProperty("manage_project")]
		public IEnumerable<ManageProjectServiceModel> ManageProject { get; set; }
		
	}
}
