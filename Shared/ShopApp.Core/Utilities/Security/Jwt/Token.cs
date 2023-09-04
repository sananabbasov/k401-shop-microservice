using System;
using K123ShopApp.Core.Entities.Concrete;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using K123ShopApp.Core.Configurations;

namespace K123ShopApp.Core.Utilities.Security.Jwt
{
	public static class Token
	{
        public static string CreateToken(User user, string role)
        {
            //JwtConfiguration jwtConfiguration = new();
            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("l3kj4afsdfdas2kl34j234j23kl4j23lkj4");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                     new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                     new Claim(JwtRegisteredClaimNames.Email, user.Email),
                     new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                     new Claim (ClaimTypes.Role, role),
                 }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "ComparAcademy",
                Audience = "ComparAcademy"
            };

            var token = jwtHandler.CreateToken(tokenDescriptor);
            return jwtHandler.WriteToken(token);

        }
    }
}

