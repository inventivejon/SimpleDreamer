using Show_SimpleDreamer_API_Servers.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Show_SimpleDreamer_API_Servers.Server.Controllers
{
    [Route("api/[controller]")]
    public class BasicBackendInformationController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult BasicBackendInformationTest()
        {
            return Ok(Program._SimpleDreamerBackendRegistryClass.GetAllBackends().ToAsyncEnumerable());
        }
    }
}
