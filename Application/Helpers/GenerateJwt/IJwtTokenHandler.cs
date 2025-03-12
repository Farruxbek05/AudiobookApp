using Domain.Entity;

namespace Application.Helpers.GenerateJwt
{
    public interface IJwtTokenHandler
    {
        string GenerateAccessToken(User user, string sessionToken);
        string GenerateRefreshToken();
    }

}
