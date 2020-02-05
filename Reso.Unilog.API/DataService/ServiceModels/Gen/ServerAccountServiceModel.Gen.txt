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
	public partial class ServerAccountServiceModel: BaseServiceModel<ServerAccount>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("note")]
		public string Note { get; set; }
		[JsonProperty("owner")]
		public string Owner { get; set; }
		[JsonProperty("password")]
		public string Password { get; set; }
		[JsonProperty("server_id")]
		public int ServerId { get; set; }
		[JsonProperty("username")]
		public string Username { get; set; }
		[JsonProperty("server")]
		public ServerServiceModel Server { get; set; }
		
		public ServerAccountServiceModel(ServerAccount entity) : base(entity)
		{
		}
		
		public ServerAccountServiceModel()
		{
		}
		
	}
	
	public partial class UpdateServerAccountServiceModel: BaseUpdateServiceModel<UpdateServerAccountServiceModel, ServerAccount>
	{
		[JsonProperty("id")]
		public Wrapper<int> Id { get; set; }
		[JsonProperty("active")]
		public Wrapper<bool> Active { get; set; }
		[JsonProperty("note")]
		public Wrapper<string> Note { get; set; }
		[JsonProperty("owner")]
		public Wrapper<string> Owner { get; set; }
		[JsonProperty("password")]
		public Wrapper<string> Password { get; set; }
		[JsonProperty("server_id")]
		public Wrapper<int> ServerId { get; set; }
		[JsonProperty("username")]
		public Wrapper<string> Username { get; set; }
		[JsonProperty("server")]
		public ServerServiceModel Server { get; set; }
		
	}
}
