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
	public partial class ApplicationRelationServiceModel: BaseServiceModel<ApplicationRelation>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("client_id")]
		public int? ClientId { get; set; }
		[JsonProperty("service_id")]
		public int? ServiceId { get; set; }
		[JsonProperty("client")]
		public ApplicationServiceModel Client { get; set; }
		[JsonProperty("service")]
		public ApplicationServiceModel Service { get; set; }
		
		public ApplicationRelationServiceModel(ApplicationRelation entity) : base(entity)
		{
		}
		
		public ApplicationRelationServiceModel()
		{
		}
		
	}
	
	public partial class UpdateApplicationRelationServiceModel: BaseUpdateServiceModel<UpdateApplicationRelationServiceModel, ApplicationRelation>
	{
		[JsonProperty("id")]
		public Wrapper<int> Id { get; set; }
		[JsonProperty("client_id")]
		public Wrapper<int?> ClientId { get; set; }
		[JsonProperty("service_id")]
		public Wrapper<int?> ServiceId { get; set; }
		[JsonProperty("client")]
		public ApplicationServiceModel Client { get; set; }
		[JsonProperty("service")]
		public ApplicationServiceModel Service { get; set; }
		
	}
}
