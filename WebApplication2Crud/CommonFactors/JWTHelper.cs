using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Web;
using WebApplication2Crud.Models;

namespace WebApplication2Crud.CommonFactors
{

    public static class JWTHelper
    {
        public static SymmetricSecurityKey _signinkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MbQeThWmZq4t7w!z"));
        public static string CreateJWTToken(Credential userinfo)
        {
            var credentials = new SigningCredentials(_signinkey, SecurityAlgorithms.HmacSha256);
            var issuer = "https://localhost:44341/";
            var audiance = "https://localhost:44341/";
            var claims = new[] {

                new Claim(ClaimTypes.Name,userinfo.UserName),
                new Claim(ClaimTypes.Role,userinfo.UserRole)

             };

            var token = new JwtSecurityToken(
                    issuer,
                    audiance,
                    claims,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: credentials
                    );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public static ClaimsPrincipal ValidatejwtToken(string token)
        {
            var h = new JwtSecurityTokenHandler();
            h.ValidateToken(token, new TokenValidationParameters()
            {
                ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha256 },
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MbQeThWmZq4t7w!z")),
                ValidateIssuerSigningKey = true,
                ValidateLifetime = false
            }, out var securityToken);
            var jwt = securityToken as JwtSecurityToken;
            var id = new ClaimsIdentity(jwt.Claims, "jwt", ClaimTypes.Name, ClaimTypes.Role);
            return new ClaimsPrincipal(id);
        }
        public static void AuthenticationRequest(string token)
        {
            //var token = HttpContext.Current.Request.Headers.Get("Autherization");
            var principal = ValidatejwtToken(token);
            HttpContext.Current.User = principal;
            Thread.CurrentPrincipal = principal;//need to work
        }
    }
}