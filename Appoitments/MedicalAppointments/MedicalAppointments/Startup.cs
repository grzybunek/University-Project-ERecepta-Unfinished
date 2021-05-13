
namespace MedicalAppointments.Web
{
    using MedicalAppointments.Domain;
    using MedicalAppointments.Domain.Services;
    using MedicalAppointments.Infrastructure.Repositories;
    using MedicalAppointments.Web.Application;
    using MedicalAppointments.Web.Application.Queries;
    using MedicalAppointments.Web.Application.Commands;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        ///
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Appointments.Web", Version = "v1" });
            });

            services.AddSingleton<IMedicalAppointmentsRepository, MedicalAppointmentsRepositories>();
            services.AddTransient<IAppointmentQueriesHandler, AppointmentQueriesHandler>();
            services.AddTransient<ICommandHandler<AddAppointmentCommand>, AppointmentsCommandsHandler>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Appointments.Web v1"));
            }

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
