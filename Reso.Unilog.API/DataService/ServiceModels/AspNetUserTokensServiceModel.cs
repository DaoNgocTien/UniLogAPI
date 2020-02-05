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
	public partial class AspNetUserTokensServiceModel: BaseServiceModel<AspNetUserTokens>
	{
		[JsonProperty("user_id")]
		public int UserId { get; set; }
		[JsonProperty("login_provider")]
		public string LoginProvider { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("value")]
		public string Value { get; set; }
		[JsonProperty("user")]
		public AspNetUsersServiceModel User { get; set; }
		
		public AspNetUserTokensServiceModel(AspNetUserTokens entity) : base(entity)
		{
		}
		
		public AspNetUserTokensServiceModel()
		{
		}
		
	}
	
	public partial class UpdateAspNetUserTokensServiceModel: BaseUpdateServiceModel<UpdateAspNetUserTokensServiceModel, AspNetUserTokens>
	{
		[JsonProperty("user_id")]
		public Wrapper<int> UserId { get; set; }
		[JsonProperty("login_provider")]
		public Wrapper<string> LoginProvider { get; set; }
		[JsonProperty("name")]
		public Wrapper<string> Name { get; set; }
		[JsonProperty("value")]
		public Wrapper<string> Value { get; set; }
		[JsonProperty("user")]
		public AspNetUsersServiceModel User { get; set; }
		
	}
}
