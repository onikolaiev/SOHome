using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SOHome.Common.DataModels;
using SOHome.Domain.Data;
using SOHome.Domain.Models;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace SOHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SOHomeDbContext dbContext;
        private readonly IMapper mapper;

        public AuthController(SOHomeDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var person = mapper.Map<Person>(model);
                var user = mapper.Map<User>(model);
                user.Person = person;
                dbContext.People.Add(person);
                dbContext.Users.Add(user);

                await dbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> RegisterAsync(LoginModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var user = await dbContext.Users
                    .Where(x => x.Username == model.Username)
                    .Where(x => x.Password == model.Password)
                    .Include(x => x.Person)
                    .Select(x => mapper.Map<UserDto>(x))
                    .FirstOrDefaultAsync();

                if (user == null)
                    return Unauthorized();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
