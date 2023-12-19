using BPOneTestAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
                ServerVersion.AutoDetect(connection),
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

            return services;
        }
    }
}