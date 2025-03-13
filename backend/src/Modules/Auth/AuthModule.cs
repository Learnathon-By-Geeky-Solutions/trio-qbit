using backend.src.Modules.Auth.Application.Interfaces;
using backend.src.Modules.Auth.Infrastructure.Persistence;
using backend.src.Modules.Auth.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Modules.Auth
{
    public static class AuthModule
    {
        public static IServiceCollection AddAuthModule(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AuthUserDbContext>(options => options.UseNpgsql(connectionString));
            //services.AddScoped<IAuthUserRepository, AuthUserRepository>();
            services.AddControllers();

            return services;
        }
    }
}