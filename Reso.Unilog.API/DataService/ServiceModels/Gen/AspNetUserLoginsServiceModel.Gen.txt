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
	public partial class AspNetUserLoginsServiceModel: BaseServiceModel<AspNetUserLogins>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("login_provider")]
		public string LoginProvider { get; set; }
		[JsonProperty("provider_display_name")]
		public string ProviderDisplayName { get; set; }
		[JsonProperty("provider_key")]
		public string ProviderKey { get; set; }
		[JsonProperty("user_id")]
		public int? UserId { get; set; }
		[JsonProperty("user")]
		public AspNetUsersServiceModel User { get; set; }
		
		public AspNetUserLoginsServiceModel(AspNetUserLogins entity) : base(entity)
		{
		}
		
		public AspNetUserLoginsServiceModel()
		{
		}
		
	}
	
	public partial class UpdateAspNetUserLoginsServiceModel: BaseUpdateServiceModel<UpdateAspNetUserLoginsServiceModel, AspNetUserLogins>
	{
		[JsonProperty("id")]
		public Wrapper<int> Id { get; set; }
		[JsonProperty("login_provider")]
		public Wrapper<string> LoginProvider { get; set; }
		[JsonProperty("provider_display_name")]
		public Wrapper<string> ProviderDisplayName { get; set; }
		[JsonProperty("provider_key")]
		public Wrapper<string> ProviderKey { get; set; }
		[JsonProperty("user_id")]
		public Wrapper<int?> UserId { get; set; }
		[JsonProperty("user")]
		public AspNetUsersServiceModel User { get; set; }
		
	}
}
