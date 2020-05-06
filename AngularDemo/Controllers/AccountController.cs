using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AngularDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AngularDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            UserManager<User> userManager,
             RoleManager<IdentityRole> roleManager,
            SignInManager<User> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            this._configuration = configuration;
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] RegisterInfo model)
        {
            
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Email, Email = model.Email, FirstName=model.FirstName,
                                      LastNames=model.LastNames ,Birthday = model.Birthday, Sex= model.Sex};
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "STUDENT");
                    var userget= await _userManager.FindByEmailAsync(model.Email);
                    return BuildToken(userget);
                }
                else
                {
                    return BadRequest("Username or password invalid");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var userget = await _userManager.FindByEmailAsync(userInfo.Email);
                    return BuildToken(userget);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        private IActionResult BuildToken(User userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim("fullname", userInfo.FirstName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["LLAVE"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // EN ESTE TIEMPO DE EXPIRACION EL TOKEN SE CIERRA Y SE GENERA UNO NUEVO, POR EN DE YA NO SIRVE LA AUTH
            var expiration = DateTime.UtcNow.AddMinutes(10);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "http://localhost:50521/",
               audience: "http://localhost:50521/",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration
            });

        }
    }
}