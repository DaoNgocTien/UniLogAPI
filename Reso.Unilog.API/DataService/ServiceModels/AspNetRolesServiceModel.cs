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
	public partial class AspNetRolesServiceModel: BaseServiceModel<AspNetRoles>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("concurrency_stamp")]
		public string ConcurrencyStamp { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("normalized_name")]
		public string NormalizedName { get; set; }
		[JsonProperty("asp_net_user_roles")]
		public IEnumerable<AspNetUserRolesServiceModel> AspNetUserRoles { get; set; }
		
		public AspNetRolesServiceModel(AspNetRoles entity) : base(entity)
		{
		}
		
		public AspNetRolesServiceModel()
		{
		}
		
	}
	
	public partial class UpdateAspNetRolesServiceModel: BaseUpdateServiceModel<UpdateAspNetRolesServiceModel, AspNetRoles>
	{
		[JsonProperty("id")]
		public Wrapper<int> Id { get; set; }
		[JsonProperty("concurrency_stamp")]
		public Wrapper<string> ConcurrencyStamp { get; set; }
		[JsonProperty("name")]
		public Wrapper<string> Name { get; set; }
		[JsonProperty("normalized_name")]
		public Wrapper<string> NormalizedName { get; set; }
		[JsonProperty("asp_net_user_roles")]
		public IEnumerable<AspNetUserRolesServiceModel> AspNetUserRoles { get; set; }
		
	}
}
