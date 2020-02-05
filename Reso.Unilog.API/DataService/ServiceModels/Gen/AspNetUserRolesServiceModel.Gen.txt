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
	public partial class AspNetUserRolesServiceModel: BaseServiceModel<AspNetUserRoles>
	{
		[JsonProperty("user_id")]
		public int UserId { get; set; }
		[JsonProperty("role_id")]
		public int RoleId { get; set; }
		[JsonProperty("role")]
		public AspNetRolesServiceModel Role { get; set; }
		[JsonProperty("user")]
		public AspNetUsersServiceModel User { get; set; }
		
		public AspNetUserRolesServiceModel(AspNetUserRoles entity) : base(entity)
		{
		}
		
		public AspNetUserRolesServiceModel()
		{
		}
		
	}
	
	public partial class UpdateAspNetUserRolesServiceModel: BaseUpdateServiceModel<UpdateAspNetUserRolesServiceModel, AspNetUserRoles>
	{
		[JsonProperty("user_id")]
		public Wrapper<int> UserId { get; set; }
		[JsonProperty("role_id")]
		public Wrapper<int> RoleId { get; set; }
		[JsonProperty("role")]
		public AspNetRolesServiceModel Role { get; set; }
		[JsonProperty("user")]
		public AspNetUsersServiceModel User { get; set; }
		
	}
}
