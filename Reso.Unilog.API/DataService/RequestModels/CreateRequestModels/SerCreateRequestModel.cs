using DataService.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.RequestModels.CreateRequestModels
{
    public  class SerCreateRequestModel
    {

        public  readonly string ServerCode = UniLogUtil.GetRandomString();
        public  readonly bool Active = true;
        public  readonly DateTime CreateTime = DateTime.UtcNow.AddHours(7);
        public  readonly DateTime UpdateTime = DateTime.UtcNow.AddHours(7);
    }
}
