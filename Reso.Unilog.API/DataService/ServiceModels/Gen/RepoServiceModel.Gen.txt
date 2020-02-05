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
	public partial class RepoServiceModel: BaseServiceModel<Repo>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("application_id")]
		public int? ApplicationId { get; set; }
		[JsonProperty("create_time")]
		public DateTime? CreateTime { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("note")]
		public string Note { get; set; }
		[JsonProperty("repo_url")]
		public string RepoUrl { get; set; }
		[JsonProperty("server_id")]
		public int ServerId { get; set; }
		[JsonProperty("update_time")]
		public DateTime? UpdateTime { get; set; }
		[JsonProperty("application")]
		public ApplicationServiceModel Application { get; set; }
		[JsonProperty("server")]
		public ServerServiceModel Server { get; set; }
		
		public RepoServiceModel(Repo entity) : base(entity)
		{
		}
		
		public RepoServiceModel()
		{
		}
		
	}
	
	public partial class UpdateRepoServiceModel: BaseUpdateServiceModel<UpdateRepoServiceModel, Repo>
	{
		[JsonProperty("id")]
		public Wrapper<int> Id { get; set; }
		[JsonProperty("active")]
		public Wrapper<bool> Active { get; set; }
		[JsonProperty("application_id")]
		public Wrapper<int?> ApplicationId { get; set; }
		[JsonProperty("create_time")]
		public Wrapper<DateTime?> CreateTime { get; set; }
		[JsonProperty("name")]
		public Wrapper<string> Name { get; set; }
		[JsonProperty("note")]
		public Wrapper<string> Note { get; set; }
		[JsonProperty("repo_url")]
		public Wrapper<string> RepoUrl { get; set; }
		[JsonProperty("server_id")]
		public Wrapper<int> ServerId { get; set; }
		[JsonProperty("update_time")]
		public Wrapper<DateTime?> UpdateTime { get; set; }
		[JsonProperty("application")]
		public ApplicationServiceModel Application { get; set; }
		[JsonProperty("server")]
		public ServerServiceModel Server { get; set; }
		
	}
}
