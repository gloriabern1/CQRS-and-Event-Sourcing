using JWTAuthenticationManager.Interface;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace JWTAuthenticationManager.Services
{
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        private readonly IDictionary<string, string> users = new Dictionary<string, string>
        {
            {"test1", "password1" },
            {"test2", "password2" }
        };
        //private key used for encryption
        private readonly string PrivateKey;
        public JWTAuthenticationManager(string key)
        {
            PrivateKey = key;
        }
        public string Authenticate(string username, string password)
        {
            //check data against database or datastore
            if(!users.Any(u=> u.Key== username && u.Value == password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes(PrivateKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenkey),
                    SecurityAlgorithms.HmacSha256Signature

                )
            };
            var Securitytoken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(Securitytoken);

            return token;
        }
    }
}
