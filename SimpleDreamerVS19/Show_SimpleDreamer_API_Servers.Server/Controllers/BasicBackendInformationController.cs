using Show_SimpleDreamer_API_Servers.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Show_SimpleDreamer_API_Servers.Server.Controllers
{
    [Route("api/[controller]")]
    public class BasicBackendInformationController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult BasicBackendInformation()
        {
            return Ok(Enumerable.Range(1, 20).Select(index =>
                 new BasicBackendInformation
                 {
                     IpAddress = "192.168.10.65",
                     Port = "80" + index.ToString("00"),
                     Name = "Default server",
                     Description = "Default server description",
                     Tags = "RandomPics",
                     Country = "Germany"
                 })
            );
        }
    }
}
