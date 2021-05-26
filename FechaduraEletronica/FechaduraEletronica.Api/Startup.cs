using FechaduraEletronica.Api.Configuration;
using FechaduraEletronica.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Text.Json.Serialization;

namespace FechaduraEletronica.Api
{
    public class Startup
    {
        private readonly IHostEnvironment Env;

        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.LoadConfiguration();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllers().AddNewtonsoftJson(c =>
            {
                c.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                c.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            }).AddJsonOptions(c =>
            {
                c.JsonSerializerOptions.IgnoreNullValues = true;
                c.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            }); ;

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FechaduraEletronica.Api", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            RepositoryConfig.ConfigureServices(services);
            ExecutorConfig.ConfigureServices(services);
            ServiceConfig.ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
            }).UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TapegandoFogoBicho.Controller v1");
                c.RoutePrefix = "swagger";
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
