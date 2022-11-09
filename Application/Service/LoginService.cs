using Application.DTO;
using Application.Service.Interface;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.SecurityConfig;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace Application.Service
{
    public class LoginService : ILoginService
    {
        
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private TokenConfiguration _configuration;
        private IUserRepository userRepository;
        private readonly ITokenRepository tokenRepository;
        private readonly IMapper _mapper;
        
        public LoginService(TokenConfiguration configuration, IUserRepository userRepository, ITokenRepository tokenRepository, IMapper mapper)
        {
            _configuration = configuration;
            this.userRepository = userRepository;
            this.tokenRepository = tokenRepository;
            _mapper = mapper;
        }

        public TokenDTO ValidateCredentials(UserDTO userDTO)
        {   var toUser = _mapper.Map<User>(userDTO);
            var user = userRepository.ValidateCredentials(toUser);
            if(user == null) return null;
            var claims = new List<Claim> { 
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            new Claim(JwtRegisteredClaimNames.AuthTime, DateTime.Now.ToString())        
            };
            var accessToken = tokenRepository.GenerateAccessToken(claims);
            var refreshToken = tokenRepository.GenerateRefreshToken();
            user.AccessToken = accessToken;
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

            userRepository.RefreshUserInfo(user);
            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            
            return new TokenDTO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
                );
        }

        public TokenDTO ValidateCredentials(AccessDTO token)
        {
            
            var accessToken = token.AccessToken;
            var refreshToken = token.RefreshToken; 
            var principal =  tokenRepository.GetPrincipalFromExpiredToken(accessToken);
            var userName = principal.Identity.Name;

            var user = userRepository.ValidateCredentials(userName) ;

            if (user == null || user.RefreshToken != refreshToken || 
               user.RefreshTokenExpiryTime <= DateTime.Now) return null;
            accessToken = tokenRepository.GenerateAccessToken(principal.Claims);
            refreshToken = tokenRepository.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            userRepository.RefreshUserInfo(user);
            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);


            return new TokenDTO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
                );

        }

        public bool RevokeToken(string userName)
        {
            return userRepository.RevokeToken(userName);
        }
    }
}
