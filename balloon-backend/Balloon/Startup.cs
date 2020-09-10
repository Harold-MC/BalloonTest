using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Balloon.Database;
using Balloon.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Balloon
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
            services.AddControllers();
            services.AddSignalR();

            services.AddDbContext<BalloonDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("MainConnection"));
            });

            services.AddCors(options =>
            {
                options.AddPolicy("_corsPolicy",
                    builder =>
                    {
                        //TODO: Lista de origenes puede estar en el appSettings
                        builder.WithOrigins("http://localhost:8080")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed((x) => true)
                            .AllowCredentials();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("_corsPolicy");

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSignalR(router => router.MapHub<BallonHub>("/hub"));
            
        }
    }
}