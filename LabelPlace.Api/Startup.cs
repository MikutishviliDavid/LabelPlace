using FluentValidation;
using LabelPlace.Api.Configurations;
using LabelPlace.Api.Profiles;
using LabelPlace.Api.Validators;
using LabelPlace.BusinessLogic.Services;
using LabelPlace.BusinessLogic.Services.Interfaces;
using LabelPlace.Dal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LabelPlace.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetSection("LabelPlaceDatabase").Get<LabelPlaceDatabaseConfiguration>();
            
            var connectionString = connection.ConnectionString;

            services.AddDbContext<LabelPlaceContext>(options =>
            options.UseNpgsql(connectionString, b => b.MigrationsAssembly("LabelPlace.Api")));

            services.AddAutoMapper(typeof(Startup).Assembly);// typeof(startup) or typeof(startup).Assembly
            services.AddControllers();
            services.AddValidatorsFromAssemblyContaining<ProjectValidator>();
            services.AddSwaggerGen();

            services.AddScoped<ICompanyService, CompanyService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LabelPlace.Api v1");
                c.RoutePrefix = string.Empty;
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