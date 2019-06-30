using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Show_SimpleDreamer_API_Servers.Server.StaticInformation;
using Show_SimpleDreamer_API_Servers.Shared;

namespace Show_SimpleDreamer_API_Servers.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class registerController : ControllerBase
    {
        [HttpPost("SimpleDreamerBackends")]
        public JsonResult PostSimpleDreamerBackends([FromBody] BasicBackendInformation body)
        {
            try
            {
                if (true == Program._SimpleDreamerBackendRegistryClass.AddBackend(body))
                {
                    return new JsonResult(JsonDefaultResponses.SimpleSuccess);
                }
                else
                {
                    throw new Exception("Could not add backend");
                }
            }
            catch
            {
                return new JsonResult(JsonDefaultResponses.SimpleFailed);
            }
        }

        [HttpPut("SimpleDreamerBackends/{id}/Ping")]
        public JsonResult PutSimpleDreamerBackends(string id)
        {
            try
            {
                Program._SimpleDreamerBackendRegistryClass.Ping(id);

                return new JsonResult(JsonDefaultResponses.SimpleSuccess);
            }
            catch
            {
                return new JsonResult(JsonDefaultResponses.SimpleFailed);
            }
        }

        [HttpDelete("SimpleDreamerBackends/{id}")]
        public JsonResult DeleteSimpleDreamerBackends(string id)
        {
            try
            {
                Program._SimpleDreamerBackendRegistryClass.RemoveBackend(id);

                return new JsonResult(JsonDefaultResponses.SimpleSuccess);
            }
            catch
            {
                return new JsonResult(JsonDefaultResponses.SimpleFailed);
            }
        }
    }
}