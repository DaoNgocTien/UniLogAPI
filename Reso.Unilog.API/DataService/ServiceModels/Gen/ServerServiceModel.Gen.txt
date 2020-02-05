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
	public partial class ServerServiceModel: BaseServiceModel<Server>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("active")]
		public bool? Active { get; set; }
		[JsonProperty("create_time")]
		public DateTime CreateTime { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("expired_date")]
		public DateTime? ExpiredDate { get; set; }
		[JsonProperty("ip_address")]
		public string IpAddress { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("os")]
		public int Os { get; set; }
		[JsonProperty("server_code")]
		public string ServerCode { get; set; }
		[JsonProperty("server_master")]
		public int? ServerMaster { get; set; }
		[JsonProperty("server_url")]
		public string ServerUrl { get; set; }
		[JsonProperty("type")]
		public int Type { get; set; }
		[JsonProperty("update_time")]
		public DateTime? UpdateTime { get; set; }
		[JsonProperty("server_detail")]
		public ServerDetailServiceModel ServerDetail { get; set; }
		[JsonProperty("server_master_navigation")]
		public ServerServiceModel ServerMasterNavigation { get; set; }
		[JsonProperty("inverse_server_master_navigation")]
		public IEnumerable<ServerServiceModel> InverseServerMasterNavigation { get; set; }
		[JsonProperty("repo")]
		public IEnumerable<RepoServiceModel> Repo { get; set; }
		[JsonProperty("server_account")]
		public IEnumerable<ServerAccountServiceModel> ServerAccount { get; set; }
		
		public ServerServiceModel(Server entity) : base(entity)
		{
		}
		
		public ServerServiceModel()
		{
		}
		
	}
	
	public partial class UpdateServerServiceModel: BaseUpdateServiceModel<UpdateServerServiceModel, Server>
	{
		[JsonProperty("id")]
		public Wrapper<int> Id { get; set; }
		[JsonProperty("active")]
		public Wrapper<bool?> Active { get; set; }
		[JsonProperty("create_time")]
		public Wrapper<DateTime> CreateTime { get; set; }
		[JsonProperty("description")]
		public Wrapper<string> Description { get; set; }
		[JsonProperty("expired_date")]
		public Wrapper<DateTime?> ExpiredDate { get; set; }
		[JsonProperty("ip_address")]
		public Wrapper<string> IpAddress { get; set; }
		[JsonProperty("name")]
		public Wrapper<string> Name { get; set; }
		[JsonProperty("os")]
		public Wrapper<int> Os { get; set; }
		[JsonProperty("server_code")]
		public Wrapper<string> ServerCode { get; set; }
		[JsonProperty("server_master")]
		public Wrapper<int?> ServerMaster { get; set; }
		[JsonProperty("server_url")]
		public Wrapper<string> ServerUrl { get; set; }
		[JsonProperty("type")]
		public Wrapper<int> Type { get; set; }
		[JsonProperty("update_time")]
		public Wrapper<DateTime?> UpdateTime { get; set; }
		[JsonProperty("server_detail")]
		public ServerDetailServiceModel ServerDetail { get; set; }
		[JsonProperty("server_master_navigation")]
		public ServerServiceModel ServerMasterNavigation { get; set; }
		[JsonProperty("inverse_server_master_navigation")]
		public IEnumerable<ServerServiceModel> InverseServerMasterNavigation { get; set; }
		[JsonProperty("repo")]
		public IEnumerable<RepoServiceModel> Repo { get; set; }
		[JsonProperty("server_account")]
		public IEnumerable<ServerAccountServiceModel> ServerAccount { get; set; }
		
	}
}
