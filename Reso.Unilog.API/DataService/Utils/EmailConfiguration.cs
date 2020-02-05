using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Utils
{
    public  interface IEmailConfiguration
    {
         string SmtpServer { get; set; }
         int SmtpPort { get; set; }
         string SmtpUsername { get; set; }
         string SmtpPassword { get; set; }

         string PopServer { get; set; }
         int PopPort { get; set; }
         string PopUsername { get; set; }
         string PopPassword { get; set; }
    }

    public  class EmailConfiguration : IEmailConfiguration
    {
        public  string SmtpServer { get ; set ; }
        public  int SmtpPort { get ; set ; }
        public  string SmtpUsername { get ; set ; }
        public  string SmtpPassword { get ; set ; }

        public  string PopServer { get ; set ; }
        public  int PopPort { get ; set ; }
        public  string PopUsername { get ; set ; }
        public  string PopPassword { get ; set ; }
    }
}
