using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleDreamer_Backend.StaticInformation;

namespace SimpleDreamer_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class versionController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(SwVersionProvider.Version);
        }
    }
}