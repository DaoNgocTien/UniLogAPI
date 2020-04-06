using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class ManageProject
    {
        public int AccountId { get; set; }
        public int? ApplicationId { get; set; }
        public int? ApplicationInstanceId { get; set; }
        public int Id { get; set; }

        public virtual Account Account { get; set; }
        public virtual Application Application { get; set; }
        public virtual ApplicationInstance ApplicationInstance { get; set; }
    }
}
