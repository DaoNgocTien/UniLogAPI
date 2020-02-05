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
	public partial class ErrorCodeServiceModel: BaseServiceModel<ErrorCode>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("create_time")]
		public DateTime? CreateTime { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("update_time")]
		public DateTime? UpdateTime { get; set; }
		[JsonProperty("log")]
		public IEnumerable<LogServiceModel> Log { get; set; }
		
		public ErrorCodeServiceModel(ErrorCode entity) : base(entity)
		{
		}
		
		public ErrorCodeServiceModel()
		{
		}
		
	}
	
	public partial class UpdateErrorCodeServiceModel: BaseUpdateServiceModel<UpdateErrorCodeServiceModel, ErrorCode>
	{
		[JsonProperty("id")]
		public Wrapper<int> Id { get; set; }
		[JsonProperty("active")]
		public Wrapper<bool> Active { get; set; }
		[JsonProperty("create_time")]
		public Wrapper<DateTime?> CreateTime { get; set; }
		[JsonProperty("description")]
		public Wrapper<string> Description { get; set; }
		[JsonProperty("name")]
		public Wrapper<string> Name { get; set; }
		[JsonProperty("update_time")]
		public Wrapper<DateTime?> UpdateTime { get; set; }
		[JsonProperty("log")]
		public IEnumerable<LogServiceModel> Log { get; set; }
		
	}
}
