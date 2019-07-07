using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SimpleDreamer_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class streamingController : ControllerBase
    {
        private static HttpClient _client { get; } = new HttpClient();

        [HttpGet]
        public IActionResult Get(CancellationToken CT)
        {
            try
            {
                CT.ThrowIfCancellationRequested();

                FileStreamResult response = File(Program._simpleDreamerContentProvider.GetSource(), "video/mp4", true);

                //Stream back to target
                return response;
            }
            catch (System.Exception ex)
            {
                //Won't trigger when stream is canceled by user, Like close browser.
                //TODO: Cancel streams
                return NotFound("Failed because:" + ex.Message + "->" + ex.StackTrace);
            }

        }
    }
}