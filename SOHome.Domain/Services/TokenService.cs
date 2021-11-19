using Microsoft.IdentityModel.Tokens;

using SOHome.Common;
using SOHome.Domain.Models;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SOHome.Domain.Services
{
    public static class TokenService
    {
        public static Claim[] GetClaims(this User user)
        {
            var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Person.Name),
                    new Claim(ClaimTypes.Role, "user"),
                    new Claim("username", user.UserName),
                    new Claim(ClaimTypes.Email, !string.IsNullOrEmpty(user.Email) ? user.Email : user.Person != null ? user.Person.Email : string.Empty),
                };

            return claims;
        }
        public static string GenerateToken(this User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AppSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(user.GetClaims()),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
