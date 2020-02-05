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
	public partial class ServerDetailServiceModel: BaseServiceModel<ServerDetail>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("disk1")]
		public string Disk1 { get; set; }
		[JsonProperty("disk2")]
		public string Disk2 { get; set; }
		[JsonProperty("disk3")]
		public string Disk3 { get; set; }
		[JsonProperty("server_id")]
		public int ServerId { get; set; }
		[JsonProperty("update_time")]
		public DateTime? UpdateTime { get; set; }
		[JsonProperty("volume_disk1")]
		public string VolumeDisk1 { get; set; }
		[JsonProperty("volume_disk2")]
		public string VolumeDisk2 { get; set; }
		[JsonProperty("volume_disk3")]
		public string VolumeDisk3 { get; set; }
		[JsonProperty("server")]
		public ServerServiceModel Server { get; set; }
		
		public ServerDetailServiceModel(ServerDetail entity) : base(entity)
		{
		}
		
		public ServerDetailServiceModel()
		{
		}
		
	}
	
	public partial class UpdateServerDetailServiceModel: BaseUpdateServiceModel<UpdateServerDetailServiceModel, ServerDetail>
	{
		[JsonProperty("id")]
		public Wrapper<int> Id { get; set; }
		[JsonProperty("active")]
		public Wrapper<bool> Active { get; set; }
		[JsonProperty("disk1")]
		public Wrapper<string> Disk1 { get; set; }
		[JsonProperty("disk2")]
		public Wrapper<string> Disk2 { get; set; }
		[JsonProperty("disk3")]
		public Wrapper<string> Disk3 { get; set; }
		[JsonProperty("server_id")]
		public Wrapper<int> ServerId { get; set; }
		[JsonProperty("update_time")]
		public Wrapper<DateTime?> UpdateTime { get; set; }
		[JsonProperty("volume_disk1")]
		public Wrapper<string> VolumeDisk1 { get; set; }
		[JsonProperty("volume_disk2")]
		public Wrapper<string> VolumeDisk2 { get; set; }
		[JsonProperty("volume_disk3")]
		public Wrapper<string> VolumeDisk3 { get; set; }
		[JsonProperty("server")]
		public ServerServiceModel Server { get; set; }
		
	}
}
