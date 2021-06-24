using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Server.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Admin")]
    public class EmployeesController : Controller
    {
        [HttpGet]
        public List<string> Get()
        {
            return new List<string>() {
                "Nancy Davolio",
                "Andrew Fuller",
                "Janet Leverling"
            };
        }
    }
}
