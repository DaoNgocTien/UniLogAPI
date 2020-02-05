using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models.Gen
{
    public  interface IGetting
    {
         int Id { get; set; }
         DateTime? CreateTime { get; set; }
         DateTime? UpdateTime { get; set; }
    }   
    
}
