using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace PassengerRoster
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // pull db connection variables from env
            var db_user = Environment.GetEnvironmentVariable("POSTGRES_USER");
            var db_pass = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
            var db_name = Environment.GetEnvironmentVariable("POSTGRES_DB");

            // set the db connection string
            var connectionString
                = $"Host=db;Database={db_name};Username={db_user};Password={db_pass}";

            // inject EF and set the db connection string
            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<Entities.PassengerContext>(
                        options => options.UseNpgsql(connectionString));

            // inject the db repository
            services
                .AddScoped<Services.IPassengerRepository, Services.PassengerRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();

            AutoMapper.Mapper.Initialize(cfg =>
                    {
                        // map the passengers entity to the passenger DTO (reading)
                        cfg.CreateMap<Entities.Passenger, Models.PassengerDto>();
                        // map the passenger DTO to the passengers entity (writing)
                        cfg.CreateMap<Models.PassengerCreationDto, Entities.Passenger>();
                    });

            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
