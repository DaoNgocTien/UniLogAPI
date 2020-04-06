using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataService.RequestModels
{
    public  class ServerDetailUpdateRequestModel
    {
        [JsonProperty("id")]
        public  int Id { get; set; }
        [JsonProperty("server_id")]
        public  int ServerId { get; set; }
        [JsonProperty("disk1")]
        public  string Disk1 { get; set; }
        [JsonProperty("volume_disk1")]
        public  string VolumeDisk1 { get; set; }
        [JsonProperty("disk2")]
        public  string Disk2 { get; set; }
        [JsonProperty("volume_disk2")]
        public  string VolumeDisk2 { get; set; }
        [JsonProperty("disk3")]
        public  string Disk3 { get; set; }
        [JsonProperty("volume_disk3")]
        public  string VolumeDisk3 { get; set; }
        public readonly bool Active = true;
        public readonly DateTime UpdateTime = DateTime.UtcNow.AddHours(7);
    }
}
