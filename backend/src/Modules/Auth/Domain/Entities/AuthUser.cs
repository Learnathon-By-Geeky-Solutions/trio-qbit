namespace backend.src.Modules.Auth.Domain.Entities
{
    public class AuthUser
    {
        public string ZitadelUserId { get; private set; } // Zitadel's "sub" claim
        public string Email { get; private set; }
        public string Username { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    }
}