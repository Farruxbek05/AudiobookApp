using Domain.Entity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Application.Helpers.GenerateJwt;

public class JwtTokenHandler : IJwtTokenHandler
{

    private readonly JwtOption jwtOption;

    public JwtTokenHandler(IOptions<JwtOption> jwtOption)
    {
        this.jwtOption = jwtOption.Value;
    }

    public string GenerateAccessToken(User user, string token)
    {
        var claims = new List<Claim>()
    {
        new Claim(CustomClaimNames.Id, user.Id.ToString()),
        new Claim(CustomClaimNames.Email, user.Email),
        new Claim(CustomClaimNames.Role, user.Role.ToString()),
        new Claim(CustomClaimNames.Token, token)
    };

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOption.SecretKey));

        var jwtToken = new JwtSecurityToken(
            issuer: jwtOption.Issuer,
            audience: jwtOption.Audience,
            expires: DateTime.UtcNow.AddMinutes(jwtOption.ExpirationInMinutes),
            claims: claims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }


    public string GenerateRefreshToken()
    {
        byte[] bytes = new byte[64];

        using var randomGenerator =
            RandomNumberGenerator.Create();

        randomGenerator.GetBytes(bytes);
        return Convert.ToBase64String(bytes);
    }
}

