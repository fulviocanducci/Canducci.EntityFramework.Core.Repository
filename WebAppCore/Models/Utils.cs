using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace WebAppCore.Models
{
    public static class Utils
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services)
        {
            services.AddScoped<DbContext, DatabaseDbContext>();
            //services.AddDbContext<DatabaseDbContext>(x => x.UseSqlite("Data Source=flepper.db"));
            services.AddDbContextPool<DatabaseDbContext>(x => x.UseSqlite("Data Source=efcore.db"));
            
            services.AddScoped<IRepositoryPeople, RepositoryPeople>();

            return services;
        }

    }
}
