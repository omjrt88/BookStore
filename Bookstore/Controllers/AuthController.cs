using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Business;
using Bookstore.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Bookstore.Security;
using Bookstore.Models;

namespace Bookstore.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private IConfiguration Configuration { get; set; }
        private static UserBusiness _userBusiness;

        public AuthController(IConfiguration configuration, BookStoreContext context)
        {
            Configuration = configuration;
            _userBusiness = new UserBusiness(context);
        }

        // GET: api/<controller>
        [HttpPost]
        public IActionResult GetToken([FromBody]User credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = _userBusiness.Login(credentials);
            if (user == null)
            {
                return Unauthorized();
            }

            var token = JwtTokenBuilder.GetSecuredToken(Configuration);

            return Ok(new
            {
                Token = JwtTokenBuilder.WriteToken(token)
            });
        }
    }
}
