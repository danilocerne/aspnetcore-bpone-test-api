using BPOneTestAPI.Domain.Interfaces;
using BPOneTestAPI.Infra.Data.Context;
using BPOneTestAPI.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace BPOneTestAPI.Infra.IoC
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructureMySql(
            this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DataBase_BPOneTestAPI");
            services.AddDbContext<ApplicationDbContext>(

                options => options.UseMySql(connection,
                    ServerVersion.Create(new Version(8, 0, 34), ServerType.MySql),
                    mySqlOptions =>
                    {
                        mySqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 10,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);

                        mySqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                    }
                )

            );
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}