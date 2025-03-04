using backend.src.Modules.SolveReview.Application.Interfaces;
using backend.src.Modules.SolveReview.Application.Mappers;
using backend.src.Modules.SolveReview.Application.Services;
using backend.src.Modules.SolveReview.Infrastructure.Persistence;
using backend.src.Modules.SolveReview.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Modules.SolveReview
{
    public static class SolveReviewModule
    {

        public static IServiceCollection AddSolveReviewModule(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SolveReviewDbContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<ISolveRepository, SolveRepository>();
            services.AddScoped<ISolveMapper, SolveMapper>();
            services.AddScoped<ISolveService, SolveService>();
            services.AddScoped<IParameterWeightsRepository, ParameterWeightsRepository>();
            services.AddScoped<IParameterWeightsService, ParameterWeightsService>();
            services.AddScoped<ITagWeightsRepository, TagWeightsRepository>(); 
            services.AddScoped<ITagWeightsService, TagWeightsService>(); 
            services.AddControllers();

            return services;
        }
    }
}