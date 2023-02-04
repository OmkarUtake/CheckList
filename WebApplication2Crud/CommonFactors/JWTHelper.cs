using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using WebApplication2Crud.Models;

namespace WebApplication2Crud.CommonFactors
{
    public static class JWTHelper
    {
        public readonly static byte[] _signinKey = Encoding.UTF8.GetBytes("MbQeThWmZq4t7w!z");

        public static string CreateJWTToken(Credential userinfo)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, userinfo.UserName));
            claims.Add(new Claim(ClaimTypes.Role, userinfo.UserRole));
            var id = new ClaimsIdentity(claims);
            var h = new JwtSecurityTokenHandler();

            var token = h.CreateToken(new SecurityTokenDescriptor()
            {
                Expires = DateTime.UtcNow.AddMinutes(10),
                Subject = id,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_signinKey), SecurityAlgorithms.HmacSha256)
            });
            return h.WriteToken(token);
        }


        public static IPrincipal ValidatejwtToken(string token)
        {
            var h = new JwtSecurityTokenHandler();
            h.ValidateToken(token, new TokenValidationParameters()
            {
                ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha256 },
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = new SymmetricSecurityKey(_signinKey),
                ValidateIssuerSigningKey = true,
                ValidateLifetime = false
            }, out var securityToken);
            var jwt = securityToken as JwtSecurityToken;
            var id = new ClaimsIdentity(jwt.Claims, "jwt", "name", "role");
            return new ClaimsPrincipal(id);
        }

        public static void AuthenticationRequest(string token)
        {
            try
            {
                //var token = HttpContext.Current.Request.Headers.Get("Autherization");
                var principal = ValidatejwtToken(token);
                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;
            }
            catch { }
        }
    }
}