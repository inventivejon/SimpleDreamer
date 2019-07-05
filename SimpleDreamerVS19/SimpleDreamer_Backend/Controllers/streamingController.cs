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
            string SourceVideoURL = "file_example_MP4_640_3MG.mp4";

            CT.ThrowIfCancellationRequested();

            try
            {
                var path = Path.Combine("", SourceVideoURL);
                FileStreamResult response = File(System.IO.File.OpenRead(path), "video/mp4");

                //Stream back to target
                return response;
            }
            catch (System.Exception ex)
            {
                //Won't trigger when stream is canceled by user, Like close browser.
                //TODO: Cancel streams
                return null;
            }

        }
    }
}