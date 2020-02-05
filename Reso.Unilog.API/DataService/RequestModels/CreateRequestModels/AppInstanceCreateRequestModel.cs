using DataService.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.RequestModelss
{
    public  class AppInstanceCreateRequestModel
    {
        public  readonly bool Active = true;
        public  readonly DateTime CreateTime = DateTime.UtcNow.AddHours(7);
        public  readonly DateTime UpdateTime = DateTime.UtcNow.AddHours(7);
        public  readonly double? ApplicationVersion = null;
        public  readonly string ReleaseUrl = null;
        public  readonly string ConfigUrl = null;
       



    }
}
