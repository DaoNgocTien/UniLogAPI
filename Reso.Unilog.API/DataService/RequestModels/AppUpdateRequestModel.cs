using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.RequestModelss
{
    public  class AppUpdateRequestModel
    {
        public  readonly bool Active = true;
        public  readonly DateTime UpdateTime = DateTime.UtcNow.AddHours(7);
        public  readonly int? Efford = null;
        public  readonly int? Team = null;
        public  readonly string SourceCodeUrl  = null;
    }
}
