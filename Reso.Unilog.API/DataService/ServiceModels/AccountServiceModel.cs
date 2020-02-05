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
	public partial class AccountServiceModel: BaseServiceModel<Account>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("active")]
		public bool? Active { get; set; }
		[JsonProperty("address")]
		public string Address { get; set; }
		[JsonProperty("asp_net_user_id")]
		public int AspNetUserId { get; set; }
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("phone")]
		public string Phone { get; set; }
		[JsonProperty("role")]
		public int Role { get; set; }
		[JsonProperty("asp_net_user")]
		public AspNetUsersServiceModel AspNetUser { get; set; }
		[JsonProperty("manage_project")]
		public IEnumerable<ManageProjectServiceModel> ManageProject { get; set; }
		
		public AccountServiceModel(Account entity) : base(entity)
		{
		}
		
		public AccountServiceModel()
		{
		}
		
	}
	
	public partial class UpdateAccountServiceModel: BaseUpdateServiceModel<UpdateAccountServiceModel, Account>
	{
		[JsonProperty("id")]
		public Wrapper<int> Id { get; set; }
		[JsonProperty("active")]
		public Wrapper<bool?> Active { get; set; }
		[JsonProperty("address")]
		public Wrapper<string> Address { get; set; }
		[JsonProperty("asp_net_user_id")]
		public Wrapper<int> AspNetUserId { get; set; }
		[JsonProperty("email")]
		public Wrapper<string> Email { get; set; }
		[JsonProperty("name")]
		public Wrapper<string> Name { get; set; }
		[JsonProperty("phone")]
		public Wrapper<string> Phone { get; set; }
		[JsonProperty("role")]
		public Wrapper<int> Role { get; set; }
		[JsonProperty("asp_net_user")]
		public AspNetUsersServiceModel AspNetUser { get; set; }
		[JsonProperty("manage_project")]
		public IEnumerable<ManageProjectServiceModel> ManageProject { get; set; }
		
	}
}
