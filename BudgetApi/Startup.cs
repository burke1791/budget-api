using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using BudgetApi.Models;

namespace BudgetApi {
  public class Startup {
    private string _connection = null;
    public Startup(IConfiguration configuration, IWebHostEnvironment environment) {
      Configuration = configuration;
      HostingEnvironment = environment;
    }

    public IConfiguration Configuration { get; }
    private IWebHostEnvironment HostingEnvironment { get; set; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {
      services.Configure<ForwardedHeadersOptions>(options => {
        options.KnownProxies.Add(IPAddress.Parse("192.168.1.9"));
      });
      
      services.AddControllers();

      var builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("DefaultConnection"));

      if (HostingEnvironment.IsDevelopment()) {
        builder.Password = Configuration["DbPassword"];
        builder["Server"] = Configuration["DbServer"];
        builder["User Id"] = Configuration["DbUser"];
      }
      
      _connection = builder.ConnectionString;

      services.AddDbContext<BudgetContext>(opt => opt.UseSqlServer(_connection));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      }

      app.UseForwardedHeaders(new ForwardedHeadersOptions {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
      });

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors();

      app.UseAuthorization();

      app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
      });
    }
  }
}
