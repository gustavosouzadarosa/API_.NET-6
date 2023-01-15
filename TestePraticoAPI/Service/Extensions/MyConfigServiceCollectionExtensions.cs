using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using Infra.Implementations;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MyConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddMyDependencyGroup(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IBaseRepository<Produto>, BaseRepository<Produto>>();
            services.AddDbContext<DataBaseContext>(opitions => opitions.UseSqlServer(connectionString));
            return services;
        }
    }
}