
//using DataService.Models;
using System;
using System.Text.RegularExpressions;
using TNT.Core.Template.DataService;
using TNT.Core.Template.DataService.Helpers;

namespace DataService

{
    public  class Class1
    {
        public  static void Main(string[] args)
        {
            //GeneralHelper.ExecuteScaffoldFromCmd(
            //    @"D:\C#\Wisky\Unilog.Reso\Reso.Unilog.API\DataService",
            //    "54.169.64.6",
            //    "UniLog.Dev", "sa", "zaQ@1234", "Models", "UnilogDevContext"
            //    );

            //Scaffold-DbContext "Server=localhost;Database=UniLogDev;user id=saisam;pwd=Katie123;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context UnilogDevContext -DataAnnotations 
            //dotnet ef dbcontext scaffold "Server=localhost; Database=UniLogDev; Trusted_Connection = true;User Id=saisam;Password=Katie123;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c UnilogDevContext - f

            //GeneralHelper.ExecuteScaffoldFromCmd(
            //    @"D:\SPRING 2020\C#\Unilog.Reso\Reso.Unilog.API\DataService",
            //    "localhost",
            //    "UniLogDev", "kachy", "091217", "Models", "UnilogDevContext", true
            //    );

            //using (var context = new UnilogDevContext())
            //{
            //    var gen = context.GetDataServiceGenerator(
            //        @"D:\SPRING 2020\C#\Unilog.Reso\Reso.Unilog.API\DataService",
            //        "DataService",
            //        GeneralHelper.JsonPropertyFormatEnum.JsonStyle,
            //        TNT.Core.Template.DataService.Data.DIContainer.ServiceProvider,
            //        true, true
            //        );
            //    gen.Generate();
            //}

            //FileHelper.ChangeTextToCsFile(
            //    @"D:\SPRING 2020\C#\Unilog.Reso\Reso.Unilog.API\DataService\ServiceModels\Gen",
            //    @"D:\SPRING 2020\C#\Unilog.Reso\Reso.Unilog.API\DataService\ServiceModels", 4
            //    );


            //if (Regex.IsMatch("123", "\\d+"))
            //{
            //    Console.WriteLine("123 true");
            //}
            //else Console.WriteLine("123 false");
            //if (Regex.IsMatch("a", "\\d+"))
            //{
            //    Console.WriteLine("a true");
            //}
            //else Console.WriteLine("a false");
            //Console.ReadKey();
        }

    }
}
