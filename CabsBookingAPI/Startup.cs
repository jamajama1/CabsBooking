using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabsBookingAPI
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
            // Dependency Injection for repositories and services
            services.AddScoped<IBookingHistoryRepository, BookingHistoryRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ICabRepository, CabRepository>();
            services.AddScoped<ILocationHistoryRepository, LocationHistoryRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IPlaceRespository, PlaceRepository>();
            services.AddScoped<IPlaceService, PlaceService>();
            services.AddScoped<IBookingHistoryService, BookingHistoryService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ICabService, CabService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ILocationHistoryService, LocationHistoryService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CabsBookingAPI", Version = "v1" });
            });

            // inject connection string from appsettings.json to App DbContext
            services.AddDbContext<CabsBookingDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("CabsBookingDbConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CabsBookingAPI v1"));
            }
            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowCredentials().AllowAnyMethod();
            });
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
