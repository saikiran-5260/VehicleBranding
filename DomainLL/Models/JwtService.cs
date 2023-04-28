using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DomainLL.Models
{
    public class JwtService
    {
        public string secreteKey { get; set; }
        public int tokenDuration { get; set; }
        private readonly IConfiguration _config;

        public JwtService(IConfiguration config) 
        {
            _config = config;
            this.secreteKey = config.GetSection("jwtConfig").GetSection("Key").Value;
            this.tokenDuration = Int32.Parse(config.GetSection("jwtConfig").GetSection("Duration").Value);
        }
        public string GenerateToken(string id, string firstname, string lastname, string email,string mobile, string gender)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.secreteKey));
            var signature = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var payload = new[]
            {
                new Claim("id",id),
                new Claim("firstname",firstname),
                new Claim("lastname",lastname),
                new Claim("email",email),
                new Claim("mobile",mobile),
                new Claim("gender",gender),
            };
            var jwtToken = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: payload,
                expires: DateTime.Now.AddMinutes(tokenDuration),
                signingCredentials: signature
                );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);

        }
    }
}
