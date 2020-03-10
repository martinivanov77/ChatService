using ChatService.Server.Models;
using ChatService.Server.SignalRHubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using AutoMapper;

namespace ChatService.Server
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

            services.AddCors(setup =>
            {
                setup.AddPolicy("AllowAllRequests", policy =>
                {
                    policy
                    .WithOrigins("http://localhost:4200") // only allow request fron the Angular Client hosted on localhost
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });
            services.AddSignalR();
            services.AddControllers();

            //Register AutoMapper

            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //DI Register
            services.AddScoped<IUserRepository, SQLUserRepository>();
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbConnectionString")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAllRequests");
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<Loopy>("/loopy");
                endpoints.MapControllers();
            });
        }
    }
}
