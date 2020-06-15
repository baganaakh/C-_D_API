using System;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AdminAPI2.Models;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.JsonWebTokens;
using System.IdentityModel.Tokens.Jwt;

namespace AdminAPI2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController :ControllerBase
    {
        private readonly IConfiguration _config;
        private List<Users> appUsers = new List<Users>
        {
            new Users { Uname="Admin", Password="Admin", Role="Admin",MemId=-2},
            new Users { Uname="Test", Password="Test", Role="Test",MemId=-3}
        };
        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody]Users login)
        {
            IActionResult response = Unauthorized();
            Users user = AuthenticateUser(login);
            if(user != null)
            {
                var tokenString = GenerateJWTToken(user);
                response = Ok(new
                {
                    token=tokenString,
                    userDetails=user,
                });
            }
            return response;
        }
        Users AuthenticateUser(Users loginCredentials)
        {
            Users user = appUsers.SingleOrDefault(x => x.Uname == 
            loginCredentials.Uname && x.Password == loginCredentials.Password);
            return user;
        }
        string GenerateJWTToken(Users userInfo)
        {
            var securityKey = new
                SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, userInfo.Uname),
                new Claim("Username",userInfo.Uname.ToString()),
                new Claim("role",userInfo.Role),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims:claims,
                expires:DateTime.Now.AddMinutes(30),
                signingCredentials:credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
