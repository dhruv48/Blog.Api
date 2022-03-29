
using Blog.Api.Extensions;
using Blog.Api.Filters;
using Blog.Api.IOCConfiguration;
using Blog.Common.Helpers;
using Blog.Common.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Blog.Api
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {



            IOCConfiguration.IOCConfiguration.Configuration(services);
            services.Configure<SMTPConfigModel>(Configuration.GetSection("SMTPConfig"));
            services.AddSingleton(Configuration);
            services.AddCors(o => o.AddPolicy(MyAllowSpecificOrigins, builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DateConverter());
            });
            services.AddJwtTokenAuthentication(Configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Blog.Api", Version = "v1" });
            });

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidateModelFilter));
            }).AddDataAnnotationsLocalization()
            .AddNewtonsoftJson(
                o =>
                {
                    o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    o.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                });


            //    }).AddJsonOptions(options =>
            //    {
            //        options.JsonSerializerOptions.Converters.Add(new validEnumConverter());
            //    });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog.Api v1");
                    c.RoutePrefix = string.Empty;
                }
                  );
            }


            app.UseCors(MyAllowSpecificOrigins);

            app.UseRouting();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthorization();
            //app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
