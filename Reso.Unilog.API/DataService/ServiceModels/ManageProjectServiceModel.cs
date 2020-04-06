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
	public partial class ManageProjectServiceModel: BaseServiceModel<ManageProject>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("account_id")]
		public int AccountId { get; set; }
		[JsonProperty("application_id")]
		public int? ApplicationId { get; set; }
		[JsonProperty("application_instance_id")]
		public int? ApplicationInstanceId { get; set; }
		[JsonProperty("account")]
		public AccountServiceModel Account { get; set; }
		[JsonProperty("application")]
		public ApplicationServiceModel Application { get; set; }
		[JsonProperty("application_instance")]
		public ApplicationInstanceServiceModel ApplicationInstance { get; set; }
		
		public ManageProjectServiceModel(ManageProject entity) : base(entity)
		{
		}
		
		public ManageProjectServiceModel()
		{
		}
		
	}
	
	public partial class UpdateManageProjectServiceModel: BaseUpdateServiceModel<UpdateManageProjectServiceModel, ManageProject>
	{
		[JsonProperty("id")]
		public Wrapper<int> Id { get; set; }
		[JsonProperty("account_id")]
		public Wrapper<int> AccountId { get; set; }
		[JsonProperty("application_id")]
		public Wrapper<int?> ApplicationId { get; set; }
		[JsonProperty("application_instance_id")]
		public Wrapper<int?> ApplicationInstanceId { get; set; }
		[JsonProperty("account")]
		public AccountServiceModel Account { get; set; }
		[JsonProperty("application")]
		public ApplicationServiceModel Application { get; set; }
		[JsonProperty("application_instance")]
		public ApplicationInstanceServiceModel ApplicationInstance { get; set; }
		
	}
}
