using AutoMapper;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using SOHome.Common.DataModels;
using SOHome.Domain.Data;
using SOHome.Domain.Models;

namespace SOHome.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly SignInManager<User> signInManager;
        private readonly SOHomeDbContext dbContext;

        public AccountController(UserManager<User> userManager,
            IMapper mapper, SignInManager<User> signInManager,
            SOHomeDbContext dbContext)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.signInManager = signInManager;
            this.dbContext = dbContext;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterModel registerModel)
        {
            var person = mapper.Map<Person>(registerModel);
            var user = mapper.Map<User>(registerModel);

            user.Person = person;

            var result = await userManager.CreateAsync(user, registerModel.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);

                return BadRequest(string.Join("\n", errors));
            }

            return Ok(mapper.Map<UserDto>(user));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginModel loginModel)
        {
            var result = await signInManager
                .PasswordSignInAsync(loginModel.Username, loginModel.Password, loginModel.RememberMe, false);

            if (!result.Succeeded)
            {
                return BadRequest("Dados inválidos!");
            }

            var user = await userManager.FindByNameAsync(loginModel.Username);
            var userDto = mapper.Map<UserDto>(user);
            return Ok(userDto);
        }
    }
}
