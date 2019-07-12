using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using APIServer;
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
        public IActionResult Get()
        {
            return Ok(Program._simpleDreamerContentProvider.GetAllSnippetGuids());
        }

        [HttpGet("{id}")]
        public IActionResult GetId(Guid id, CancellationToken CT)
        {
            try
            {
                //http://localhost:48445/api/streaming/2a2154f7-4b87-43d6-bcae-c15b88f263b2
                CT.ThrowIfCancellationRequested();

                var response = File(Program._simpleDreamerContentProvider.GetSource(id), "video/mp4", false);

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