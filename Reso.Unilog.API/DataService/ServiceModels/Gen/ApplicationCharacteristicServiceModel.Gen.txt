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
	public partial class ApplicationCharacteristicServiceModel: BaseServiceModel<ApplicationCharacteristic>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("actual_efford")]
		public int? ActualEfford { get; set; }
		[JsonProperty("application_id")]
		public int ApplicationId { get; set; }
		[JsonProperty("application")]
		public ApplicationServiceModel Application { get; set; }
		
		public ApplicationCharacteristicServiceModel(ApplicationCharacteristic entity) : base(entity)
		{
		}
		
		public ApplicationCharacteristicServiceModel()
		{
		}
		
	}
	
	public partial class UpdateApplicationCharacteristicServiceModel: BaseUpdateServiceModel<UpdateApplicationCharacteristicServiceModel, ApplicationCharacteristic>
	{
		[JsonProperty("id")]
		public Wrapper<int> Id { get; set; }
		[JsonProperty("active")]
		public Wrapper<bool> Active { get; set; }
		[JsonProperty("actual_efford")]
		public Wrapper<int?> ActualEfford { get; set; }
		[JsonProperty("application_id")]
		public Wrapper<int> ApplicationId { get; set; }
		[JsonProperty("application")]
		public ApplicationServiceModel Application { get; set; }
		
	}
}
