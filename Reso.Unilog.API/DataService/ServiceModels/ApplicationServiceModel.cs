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
	public partial class ApplicationServiceModel: BaseServiceModel<Application>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("category")]
		public int Category { get; set; }
		[JsonProperty("create_time")]
		public DateTime? CreateTime { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("efford")]
		public int? Efford { get; set; }
		[JsonProperty("end_date")]
		public DateTime? EndDate { get; set; }
		[JsonProperty("is_done")]
		public bool? IsDone { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("note")]
		public string Note { get; set; }
		[JsonProperty("origin")]
		public string Origin { get; set; }
		[JsonProperty("priority")]
		public int Priority { get; set; }
		[JsonProperty("source_code_url")]
		public string SourceCodeUrl { get; set; }
		[JsonProperty("stage")]
		public int? Stage { get; set; }
		[JsonProperty("start_date")]
		public DateTime StartDate { get; set; }
		[JsonProperty("status")]
		public int Status { get; set; }
		[JsonProperty("systems_id")]
		public int? SystemsId { get; set; }
		[JsonProperty("team")]
		public int? Team { get; set; }
		[JsonProperty("technologies")]
		public string Technologies { get; set; }
		[JsonProperty("type")]
		public string Type { get; set; }
		[JsonProperty("update_time")]
		public DateTime? UpdateTime { get; set; }
		[JsonProperty("systems")]
		public SystemsServiceModel Systems { get; set; }
		[JsonProperty("application_instance")]
		public IEnumerable<ApplicationInstanceServiceModel> ApplicationInstance { get; set; }
		[JsonProperty("manage_project")]
		public IEnumerable<ManageProjectServiceModel> ManageProject { get; set; }
		[JsonProperty("repo")]
		public IEnumerable<RepoServiceModel> Repo { get; set; }
		
		public ApplicationServiceModel(Application entity) : base(entity)
		{
		}
		
		public ApplicationServiceModel()
		{
		}
		
	}

	public class ApplicationResponseModel: ApplicationServiceModel
	{
		[JsonProperty("log_count")]
		public int LogCount { get; set; }
	}
	
	public partial class UpdateApplicationServiceModel: BaseUpdateServiceModel<UpdateApplicationServiceModel, Application>
	{
		[JsonProperty("id")]
		public Wrapper<int> Id { get; set; }
		[JsonProperty("active")]
		public Wrapper<bool> Active { get; set; }
		[JsonProperty("category")]
		public Wrapper<int> Category { get; set; }
		[JsonProperty("create_time")]
		public Wrapper<DateTime?> CreateTime { get; set; }
		[JsonProperty("description")]
		public Wrapper<string> Description { get; set; }
		[JsonProperty("efford")]
		public Wrapper<int?> Efford { get; set; }
		[JsonProperty("end_date")]
		public Wrapper<DateTime?> EndDate { get; set; }
		[JsonProperty("is_done")]
		public Wrapper<bool?> IsDone { get; set; }
		[JsonProperty("name")]
		public Wrapper<string> Name { get; set; }
		[JsonProperty("note")]
		public Wrapper<string> Note { get; set; }
		[JsonProperty("origin")]
		public Wrapper<string> Origin { get; set; }
		[JsonProperty("priority")]
		public Wrapper<int> Priority { get; set; }
		[JsonProperty("source_code_url")]
		public Wrapper<string> SourceCodeUrl { get; set; }
		[JsonProperty("stage")]
		public Wrapper<int?> Stage { get; set; }
		[JsonProperty("start_date")]
		public Wrapper<DateTime> StartDate { get; set; }
		[JsonProperty("status")]
		public Wrapper<int> Status { get; set; }
		[JsonProperty("systems_id")]
		public Wrapper<int?> SystemsId { get; set; }
		[JsonProperty("team")]
		public Wrapper<int?> Team { get; set; }
		[JsonProperty("technologies")]
		public Wrapper<string> Technologies { get; set; }
		[JsonProperty("type")]
		public Wrapper<string> Type { get; set; }
		[JsonProperty("update_time")]
		public Wrapper<DateTime?> UpdateTime { get; set; }
		[JsonProperty("systems")]
		public SystemsServiceModel Systems { get; set; }
		[JsonProperty("application_instance")]
		public IEnumerable<ApplicationInstanceServiceModel> ApplicationInstance { get; set; }
		[JsonProperty("manage_project")]
		public IEnumerable<ManageProjectServiceModel> ManageProject { get; set; }
		[JsonProperty("repo")]
		public IEnumerable<RepoServiceModel> Repo { get; set; }
		
	}
}
