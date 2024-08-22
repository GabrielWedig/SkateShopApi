using SkateShop.Domain.Authentication;
using SkateShop.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SkateShop.Infrastructure.Authentication
{
    public sealed class JwtProvider : IJwtProvider
    {
        public readonly JwtOptions _options;
        public readonly DataContext _context;

        public JwtProvider(IOptions<JwtOptions> options, DataContext context)
        {
            _options = options.Value;
            _context = context;
        }

        public string Generate(User user)
        {
            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            };

            var permissions = _context.Permissions.Where(p => p.UserId == user.Id);

            foreach (var permission in permissions)
            {
                claims.Add(new("permissions", permission.Name));
            }

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));

            var signingCredentials = new SigningCredentials(
                symmetricSecurityKey,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                notBefore: null,
                expires: DateTime.UtcNow.AddHours(24),
                signingCredentials: signingCredentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;

        }
    }
}
