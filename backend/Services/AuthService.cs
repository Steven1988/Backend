using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using fullstackApp.Controllers;
using fullstackApp.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;

namespace fullstackApp.Services {
    public class AuthService : IAuth {

        private readonly IUsers _users;
        private readonly TokenManagement _token;

        public AuthService(IUsers users, TokenManagement token)
        {
            _users = users;
            _token = token;
        }

        public async Task<AuthenticationResult> RegisterAsync(string email, string password) {
            
            var existingUser = await _users.FindByEmailAsync(email);

            if(existingUser != null) {
                return new AuthenticationResult {
                    ErrorMessage = "Error"
                };
            }
            var newUser = new User {
                Email = email,
                Name = email
            };


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_token.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity( new [] {
                    new Claim(JwtRegisteredClaimNames.Sub, newUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, newUser.Email),
                    // new Claim(Guid.NewGuid(), newUser.Id)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) 
            }; 

            var token  = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthenticationResult {
                Success = true,
                Token = tokenHandler.WriteToken(token) 
            };
        }
        // Task<AuthenticationResult> RegisterAsync(string email, string password);

        public bool IsAuthenticated(TokenRequest request, out string token) {
            throw new System.NotImplementedException();
        }
    }
}