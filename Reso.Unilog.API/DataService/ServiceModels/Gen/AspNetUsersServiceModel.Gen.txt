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
	public partial class AspNetUsersServiceModel: BaseServiceModel<AspNetUsers>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("access_failed_count")]
		public int AccessFailedCount { get; set; }
		[JsonProperty("concurrency_stamp")]
		public string ConcurrencyStamp { get; set; }
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("email_confirmed")]
		public bool EmailConfirmed { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("password_hash")]
		public string PasswordHash { get; set; }
		[JsonProperty("phone_number")]
		public string PhoneNumber { get; set; }
		[JsonProperty("phone_number_confirmed")]
		public bool PhoneNumberConfirmed { get; set; }
		[JsonProperty("security_stamp")]
		public string SecurityStamp { get; set; }
		[JsonProperty("two_factor_enabled")]
		public bool TwoFactorEnabled { get; set; }
		[JsonProperty("account")]
		public AccountServiceModel Account { get; set; }
		[JsonProperty("asp_net_user_logins")]
		public IEnumerable<AspNetUserLoginsServiceModel> AspNetUserLogins { get; set; }
		[JsonProperty("asp_net_user_roles")]
		public IEnumerable<AspNetUserRolesServiceModel> AspNetUserRoles { get; set; }
		[JsonProperty("asp_net_user_tokens")]
		public IEnumerable<AspNetUserTokensServiceModel> AspNetUserTokens { get; set; }
		
		public AspNetUsersServiceModel(AspNetUsers entity) : base(entity)
		{
		}
		
		public AspNetUsersServiceModel()
		{
		}
		
	}
	
	public partial class UpdateAspNetUsersServiceModel: BaseUpdateServiceModel<UpdateAspNetUsersServiceModel, AspNetUsers>
	{
		[JsonProperty("id")]
		public Wrapper<int> Id { get; set; }
		[JsonProperty("access_failed_count")]
		public Wrapper<int> AccessFailedCount { get; set; }
		[JsonProperty("concurrency_stamp")]
		public Wrapper<string> ConcurrencyStamp { get; set; }
		[JsonProperty("email")]
		public Wrapper<string> Email { get; set; }
		[JsonProperty("email_confirmed")]
		public Wrapper<bool> EmailConfirmed { get; set; }
		[JsonProperty("name")]
		public Wrapper<string> Name { get; set; }
		[JsonProperty("password_hash")]
		public Wrapper<string> PasswordHash { get; set; }
		[JsonProperty("phone_number")]
		public Wrapper<string> PhoneNumber { get; set; }
		[JsonProperty("phone_number_confirmed")]
		public Wrapper<bool> PhoneNumberConfirmed { get; set; }
		[JsonProperty("security_stamp")]
		public Wrapper<string> SecurityStamp { get; set; }
		[JsonProperty("two_factor_enabled")]
		public Wrapper<bool> TwoFactorEnabled { get; set; }
		[JsonProperty("account")]
		public AccountServiceModel Account { get; set; }
		[JsonProperty("asp_net_user_logins")]
		public IEnumerable<AspNetUserLoginsServiceModel> AspNetUserLogins { get; set; }
		[JsonProperty("asp_net_user_roles")]
		public IEnumerable<AspNetUserRolesServiceModel> AspNetUserRoles { get; set; }
		[JsonProperty("asp_net_user_tokens")]
		public IEnumerable<AspNetUserTokensServiceModel> AspNetUserTokens { get; set; }
		
	}
}
