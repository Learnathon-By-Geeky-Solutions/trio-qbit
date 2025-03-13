using backend.src.Modules.Auth.Domain.Entities;

namespace backend.src.Modules.Auth.Application.Interfaces
{
    public interface IAuthUserRepository
    {
        Task<bool> AddAsync(AuthUser user);
    }
}