﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OrderManagement.DataAccess;

namespace OrderManagement.Web
{
    /// <summary>
    /// Методы расширений для ServiceCollection дабы не захламлять стартап
    /// </summary>
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(builder =>
            {
                builder.EnableSensitiveDataLogging(true);

                builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services
                .AddScoped<IDbRepository, EfRepository>(provider =>
                    new EfRepository(provider.GetRequiredService<DataContext>()));
            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ObjectiveManagement", Version = "v1" });
            });
            return services;
        }
    }
}
