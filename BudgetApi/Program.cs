using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BudgetApi {
  public class Program {
    public static void Main(string[] args) {
      var host = new HostBuilder()
        .ConfigureAppConfiguration((hostContext, builder) => {
          if (hostContext.HostingEnvironment.IsDevelopment() || hostContext.HostingEnvironment.IsProduction()) {
            builder.AddUserSecrets<Program>();
          }
        })
        .Build();
      
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => {
              webBuilder.UseStartup<Startup>();
            });
  }
}
