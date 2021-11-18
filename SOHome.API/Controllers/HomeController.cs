using Microsoft.AspNetCore.Mvc;

using SOHome.Common.DataModels;

using System.Collections.Generic;

namespace SOHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("profile")]
        public IActionResult Profile()
        {
            return Ok(new List<PersonModel>
            {
                new PersonModel
                {
                    Name = "asdsadsa",
                    Document = "0560550"
                }
            });
        }
    }
}
