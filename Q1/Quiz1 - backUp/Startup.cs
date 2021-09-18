using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quiz1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Quiz1.Handler;

namespace Quiz1
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
            services.AddAuthentication().
            AddScheme<AuthenticationSchemeOptions, AuthHandler>
            ("StaffAuthentication", null).
            AddScheme<AuthenticationSchemeOptions, AuthHandler>
            ("StudentAuthentication", null); ;
            services.AddDbContext<Q1DBContext>(options => options.UseSqlite(Configuration.GetConnectionString("WebAPIConnection")));
            services.AddControllers();
            services.AddScoped<IQ1Repo, DBQ1Repo>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("StaffOnly", policy => policy.RequireClaim("Staff"));
                options.AddPolicy("StudentOnly", policy => policy.RequireClaim("Student"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
