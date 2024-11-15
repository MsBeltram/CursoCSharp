using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Inventory.Persistence.Interfaces;
using Inventory.Persistence.Repositories;

namespace Inventory.Persistence
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddContextSqlServer(
        this IServiceCollection services,
        IConfiguration configuration,
        String conectionString)
        {
            services.AddSqlServer<DataContext>(configuration.GetConnectionString(conectionString));
            return services;
        }

        public static IServiceCollection AddRepositories (
            this IServiceCollection services
        )
        {
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IInventoryMovementRepository,InventoryMovementRepository>();
            services.AddScoped<IInventoryStockRepository,InventoryStockRepository>();
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<ISupplierRepository,SupplierRepository>();
            services.AddScoped<IMovementTypeRepository,MovementTypeRepository>();



            return services;
        }


        public static IServiceCollection AddAuthContextSqlServer(
            this IServiceCollection services,
            IConfiguration configuration,
            string connectionStringName
        ){
            services.AddSqlServer<AuthContext>(configuration.GetConnectionString(connectionStringName));
            return services;
        }
        
    }
}
