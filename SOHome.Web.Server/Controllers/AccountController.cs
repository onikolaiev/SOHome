using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        private readonly RoleManager<UserGroup> roleManager;

        public AccountController(UserManager<User> userManager,
            IMapper mapper, SignInManager<User> signInManager,
            SOHomeDbContext dbContext, RoleManager<UserGroup> roleManager)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.signInManager = signInManager;
            this.dbContext = dbContext;
            this.roleManager = roleManager;
        }
        [AllowAnonymous]
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

                return Unauthorized(string.Join("\n", errors));
            }

            return Ok(mapper.Map<UserDto>(user));
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginModel loginModel)
        {
            var result = await signInManager
                .PasswordSignInAsync(loginModel.Username, loginModel.Password, loginModel.RememberMe, false);

            if (!result.Succeeded)
            {
                return Unauthorized("Dados inválidos!");
            }

            var user = await dbContext.Users
                .Include(x => x.Person)
                .FirstAsync(x => x.NormalizedUserName == loginModel.Username.ToUpper());
            var userDto = mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPost("group")]
        public async Task<IActionResult> AddGroupAsync(UserGroupModel groupModel)
        {
            var roleExists = await roleManager.RoleExistsAsync(groupModel.Name);
            if (roleExists)
            {
                return BadRequest("Grupo já existe");
            }

            var role = mapper.Map<UserGroup>(groupModel);
            var result = await roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                return BadRequest("Erro criar grupo!");
            }

            return Ok(groupModel);
        }

        [HttpGet("group")]
        public async Task<IActionResult> GetGroupsAsync()
        {
            var roles = await dbContext.Roles.ToArrayAsync();

            return Ok(roles);
        }
    }
}
