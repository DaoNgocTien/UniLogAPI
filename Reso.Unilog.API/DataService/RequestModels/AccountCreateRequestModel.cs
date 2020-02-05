using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataService.RequestModels
{
    public  class AccountCreateRequestModel : CreateRequestModel
    {

        [JsonProperty("email")]
        public  string Email { get; set; }
        //[JsonProperty("company_id")]
        //public  int CompanyId { get; set; }        
        [JsonProperty("address")]
        public  string Address { get; set; }
        [JsonIgnore]
        [JsonProperty("id_asp_net_user")]
        public  int AspNetUserId { get; set; }
        [JsonProperty("name")]
        public  string Name { get; set; }
        [JsonProperty("phone")]
        public  string Phone { get; set; }
        //  Default: token_v2_7/2019
        [JsonProperty("manager_registration_token")]
        public  string ManagerRegistrationToken { get; set; }
        //[JsonIgnore]
        [JsonProperty("role")]
        public  int Role { get; set; }
    }

    
}
