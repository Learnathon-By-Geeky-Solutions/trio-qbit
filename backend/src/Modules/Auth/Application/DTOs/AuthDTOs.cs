public class RegisterDto  // Not used anymore since we're redirecting
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class TokenResponseDto
{
    public string AccessToken { get; set; }
    public string IdToken { get; set; }
    public int ExpiresIn { get; set; }
    public string TokenType { get; set; }
}