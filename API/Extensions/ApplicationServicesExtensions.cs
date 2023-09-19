using Application.UnitOfWork;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    
    public static class AplicationServicesExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>{
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
        });
        public static void AppConfigure(this IServiceCollection services){
            services.AddScoped<IUnitOfWork,UnitOfWork>();
        }
    }
  
}