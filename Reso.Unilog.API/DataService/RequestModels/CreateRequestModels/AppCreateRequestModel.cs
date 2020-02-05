using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.RequestModels
{
    public  class AppCreateRequestModel
    {
        public  readonly bool IsDone  = false;
        public  readonly bool Active = true;
        public  readonly DateTime CreateTime = DateTime.UtcNow.AddHours(7);
        public  readonly DateTime? UpdateTime = null;
        public  readonly int? Team = null;
        
        public  readonly int? Efford = null;
    }
}
