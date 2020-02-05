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
	public partial class SystemsServiceModel: BaseServiceModel<Systems>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("active")]
		public bool? Active { get; set; }
		[JsonProperty("create_time")]
		public DateTime? CreateTime { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("update_time")]
		public DateTime? UpdateTime { get; set; }
		[JsonProperty("application")]
		public IEnumerable<ApplicationServiceModel> Application { get; set; }
		[JsonProperty("manage_project")]
		public IEnumerable<ManageProjectServiceModel> ManageProject { get; set; }
		
		public SystemsServiceModel(Systems entity) : base(entity)
		{
		}
		
		public SystemsServiceModel()
		{
		}
		
	}
	
	public partial class UpdateSystemsServiceModel: BaseUpdateServiceModel<UpdateSystemsServiceModel, Systems>
	{
		[JsonProperty("id")]
		public Wrapper<int> Id { get; set; }
		[JsonProperty("active")]
		public Wrapper<bool?> Active { get; set; }
		[JsonProperty("create_time")]
		public Wrapper<DateTime?> CreateTime { get; set; }
		[JsonProperty("description")]
		public Wrapper<string> Description { get; set; }
		[JsonProperty("name")]
		public Wrapper<string> Name { get; set; }
		[JsonProperty("update_time")]
		public Wrapper<DateTime?> UpdateTime { get; set; }
		[JsonProperty("application")]
		public IEnumerable<ApplicationServiceModel> Application { get; set; }
		[JsonProperty("manage_project")]
		public IEnumerable<ManageProjectServiceModel> ManageProject { get; set; }
		
	}
}
