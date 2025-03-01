using backend.src.Modules.SolveReview.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Modules.SolveReview
{
    public static class SolveReviewModule
    {

        public static IServiceCollection AddSolveReviewModule(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SolveReviewDbContext>(options => options.UseNpgsql(connectionString));
            
            return services;
        }
    }
}