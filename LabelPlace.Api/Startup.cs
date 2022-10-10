using FluentValidation;
using FluentValidation.AspNetCore;
using LabelPlace.Api.Configurations;
using LabelPlace.Api.Validators;
using LabelPlace.BusinessLogic.Services;
using LabelPlace.BusinessLogic.Services.Interfaces;
using LabelPlace.Dal;
using LabelPlace.Dal.Repositories.Implementations;
using LabelPlace.Dal.Repositories.Interfaces;
using LabelPlace.Dal.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LabelPlace.Api.Middleware;

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

            services.AddAutoMapper(typeof(Profiles.MappingProfile).Assembly, typeof(BusinessLogic.Profiles.MappingProfile).Assembly);
            services.AddControllers();
            services.AddSwaggerGen();

            services.AddScoped<ICompanyService, CompanyService>();

            services.AddValidatorsFromAssemblyContaining<CompanyValidator>();
            services.AddFluentValidationAutoValidation();

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ExceptionHandler>();

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