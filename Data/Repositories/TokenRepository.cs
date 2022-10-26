using Domain.Repositories;
using Domain.SecurityConfig;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class TokenRepository : ITokenRepository
    {
       private TokenConfigurations _configuration;

        public TokenRepository(TokenConfigurations configuration)
        {
            _configuration = configuration;
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Secret));
            var signinCredentials =new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration.Issuer,
                audience: _configuration.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_configuration.Minutes),
                signingCredentials: signinCredentials
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }

        public Task<string> GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }

        public Task<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
