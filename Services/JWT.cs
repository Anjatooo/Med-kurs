using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApplication3.Models;

namespace WebApplication3.Services
{
    public class JWT
    {
        private readonly Auth _authOptions;
        public JWT(IOptions<Auth> options)
        {
            _authOptions = options.Value;
        }
        public string JwtGeneration(User user)
        {
            System.Diagnostics.Debug.WriteLine($"SecretKey length: {_authOptions.SecretKey.Length}");
            System.Diagnostics.Debug.WriteLine($"SecretKey value: '{_authOptions.SecretKey}'");

            var claims = new List<Claim>
            {
                new Claim(type: "UserName", user.Name),
                new Claim(type: "FirstName", user.FirstName),
                new Claim(type: "id", user.Id.ToString())
            };

            var jwtToken = new JwtSecurityToken(
                expires: DateTime.UtcNow.Add(_authOptions.Expires),
                claims: claims,
                signingCredentials:
                new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_authOptions.SecretKey)),
                    algorithm: SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
                    


        }
    }
}
