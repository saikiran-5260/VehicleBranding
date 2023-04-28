using DomainLL.Data;
using DomainLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VehicleBranding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("VehicleBranding")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _config;
        public UserController(ApplicationDbContext db, IConfiguration config) {
            _db= db;
            _config= config;
        }

        [AllowAnonymous]
        [HttpPost("CreateUser")]
        public IActionResult Create(User user)
        {
            if(_db.Users.Where(u=>u.email==user.email).FirstOrDefault() != null)
            {
                return Ok("Already Exits");
            }
            user.memberSince= DateTime.Now;
            _db.Users.Add(user);
            _db.SaveChanges();
            return Ok("Success");
        }
        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public IActionResult Login(Login user)
        {
            var userAvailable  = _db.Users.Where(u=>u.email== user.email && u.pwd==user.pwd).FirstOrDefault();
            if (userAvailable != null)
            {
                return Ok(new JwtService(_config).GenerateToken(
                    userAvailable.userId.ToString(),
                    userAvailable.firstName,
                    userAvailable.lastName,
                    userAvailable.email,
                    userAvailable.mobile,
                    userAvailable.gender
                    
                    ));
            }
            return Ok("Failure");
        }
    }
}
