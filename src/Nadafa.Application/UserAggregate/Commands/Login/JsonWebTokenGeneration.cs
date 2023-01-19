using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Nadafa.SharedKernal.Shared.CurrentUser;
using Nadafa.SharedKernal.Shared.Enums;
using Nadafa.SharedKernal.Shared.JwtConfig;
using Nadafa.Users.Domain.UserAggregate.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace Nadafa.Users.Application.UserAggregate.Commands.Login
{
    public static class JsonWebTokenGeneration
    {
        public static string GenerateJwtToken(IConfiguration configuration, User user)
        {
            // Get JWt Configuration
            var config = configuration.GetSection("UserClientConfig").Get<UserClientConfig>();
            var signingKey = Convert.FromBase64String(config.Jwt.Key);


            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimKeys.Id, user.Id.ToString()));
            claims.Add(new Claim(ClaimKeys.Email, user.Email ?? ""));
            claims.Add(new Claim(ClaimKeys.Name, user.Name));
            // add image claim
            // add address claim
            claims.Add(new Claim(ClaimTypes.Role, Enum.GetName(typeof(Roles), user.Role) ?? ""));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = config.Jwt.Issuer,
                Audience = config.Jwt.Audience,
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(config.Jwt.ExpiryDuration),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var token = jwtTokenHandler.WriteToken(jwtToken);

            return token;
        }
    }
}
