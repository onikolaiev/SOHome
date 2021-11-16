using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SOHome.Common.DataModels;
using SOHome.Domain.Data;
using SOHome.Domain.Models;

using System;
using System.Threading.Tasks;

namespace SOHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SOHomeDbContext dbContext;
        private readonly IMapper mapper;

        public UsersController(SOHomeDbContext dbContext, IMapper mapper)
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
    }
}
