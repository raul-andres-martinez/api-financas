using Finances.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Finances.Service.Extensions;
using System;
using System.IO;
using System.Reflection;

namespace Finances.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServices();

            //services.AddCors();
            services.AddControllers();

            var connectionString = Configuration.GetConnectionString("AppConnection");
            services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddSwaggerGen
            (
                s =>
                {
                    s.SwaggerDoc("v1", new OpenApiInfo { Title = "Banco Master API", Version = "v1" });

                    //s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                    //{
                    //    Name = "Authorization",
                    //    Type = SecuritySchemeType.ApiKey,
                    //    Scheme = "Bearer",
                    //    BearerFormat = "JWT",
                    //    In = ParameterLocation.Header,
                    //    Description = "JWT authorization header utiliza: Bearer + JWT Token",
                    //}
                    //);
                    //s.AddSecurityRequirement(
                    //    new OpenApiSecurityRequirement
                    //    {
                    //{
                    //    new OpenApiSecurityScheme
                    //    {
                    //        Reference = new OpenApiReference
                    //        {
                    //            Type = ReferenceType.SecurityScheme,
                    //            Id = "Bearer"
                    //        }
                    //    },
                    //    new List<string>()
                    //}
                    //    }
                    //);

                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    s.IncludeXmlComments(xmlPath);
                }           
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)
        {
            if (env.IsDevelopment())
            {
                context.Database.EnsureCreated();
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Finan�as v1");
                    c.RoutePrefix = string.Empty;
                });
            }

            //app.UseCors(c => c
            //.AllowAnyOrigin()
            //.AllowAnyMethod()
            //.AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
