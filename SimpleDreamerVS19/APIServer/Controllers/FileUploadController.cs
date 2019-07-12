using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using APIServer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SimpleDreamer_Backend.Behvaior;

namespace SimpleDreamer_Backend.Controllers
{
    public class FileDescriptionShort
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<IFormFile> File { get; set; }
    }

    [Route("api/[controller]")]
    [DisableRequestSizeLimit]
    public class FileUploadController : Controller
    {
        private readonly IHubContext<ImagesMessageHub> _hubContext;
        private readonly IHubContext<VideoStreamHub> _hubVideoStreamContext;

        public FileUploadController(IHubContext<ImagesMessageHub> hubContext, IHubContext<VideoStreamHub> hubVideoStreamContext)
        {
            _hubContext = hubContext;
            _hubVideoStreamContext = hubVideoStreamContext;
        }

        [Route("files")]
        [HttpPost]
        [ServiceFilter(typeof(ValidateMimeMultipartContentFilter))]
        public async Task<IActionResult> UploadFiles(FileDescriptionShort fileDescriptionShort)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in fileDescriptionShort.File)
                {
                    if (file.Length > 0 && file.ContentType.Contains("image"))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);

                            var imageMessage = new ImageMessage
                            {
                                ImageHeaders = "data:" + file.ContentType + ";base64,",
                                ImageBinary = memoryStream.ToArray()
                            };

                            await _hubContext.Clients.All.SendAsync("ImageMessage", imageMessage);
                        }
                    }
                    else if (file.Length > 0 && file.ContentType.Contains("video"))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);


                            var videoContent = new VideoContent
                            {
                                VideoBinary = memoryStream.ToArray()
                            };

                            Guid myNewGuid = Program._simpleDreamerContentProvider.AddVideoData(videoContent);

                            var videoMessage = new VideoMessage
                            {
                                ImageHeaders = "data:" + file.ContentType + ";base64,",
                                Url = "http://localhost:48445/api/streaming/2a2154f7-4b87-43d6-bcae-c15b88f263b2" //$"/api/streaming/{myNewGuid}"
                            };

                            if (!myNewGuid.Equals(Guid.Empty))
                            {
                                await _hubVideoStreamContext.Clients.All.SendAsync("VideoMessage", videoMessage);
                            }
                        }
                    }
                }
            }

            return Redirect("/FileClient/Index");
        }
    }
}