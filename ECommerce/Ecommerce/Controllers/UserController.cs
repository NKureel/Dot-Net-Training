using Ecommerce.Interfaces;
using Ecommerce.Models;
using Ecommerce.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    
        [Authorize]
        [Route("api/[controller]")]
        [ApiController]
        public class UsersController : ControllerBase
        {
            private readonly IJWTAuthentication iJWTManager;

            public UsersController(IJWTAuthentication jWTManager)
            {
                iJWTManager = jWTManager;
            }

            [HttpGet]
            public List<string> Get()
            {
                var users = new List<string> { "Amit", "Vikash Verma", "Raj Kumar" };
                return users;
            }
            [AllowAnonymous]
            [HttpPost]
            [Route("authenticate")]
            public IActionResult Authenticate(Users userdata)
            {
                var token = iJWTManager.Authenticate(userdata);
                if (token == null)
                {
                    return Unauthorized();
                }
                return Ok(token);
            }
        }
    }
