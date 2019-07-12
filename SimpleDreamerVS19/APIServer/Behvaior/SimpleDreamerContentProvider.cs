using APIServer.StaticInformation;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleDreamer_Backend.Behvaior
{
    public class ImageMessage
    {
        public byte[] ImageBinary { get; set; }
        public string ImageHeaders { get; set; }
    }

    public class ImagesMessageHub : Hub
    {
        public Task ImageMessage(ImageMessage file)
        {
            return Clients.All.SendAsync("ImageMessage", file);
        }
    }

    public class VideoMessage
    {
        public string Url { get; set; }
        public string ImageHeaders { get; set; }
    }

    public class VideoContent
    {
        public byte[] VideoBinary { get; set; }
    }

    public class VideoStreamHub : Hub
    {
        public Task VideoMessage(VideoMessage file)
        {
            return Clients.All.SendAsync("VideoMessage", file);
        }
    }

    public class SimpleDreamerContentProvider
    {
        const string videoBasePath = "./assets/Videos/";
        static readonly string[] FileList = { "file_example_MP4_640_3MG.mp4", "Aerial Shot Of Forest Covered In Snow.mp4" };
        int CurrentVideo = 0;
        DateTime nextSourceTimePoint;

        private ConcurrentDictionary<Guid, VideoContent> _AllVideoSnippets;
        private ConcurrentDictionary<Guid, VideoContent> AllVideoSnippets
        {
            get
            {
                if(null == _AllVideoSnippets)
                {
                    _AllVideoSnippets = new ConcurrentDictionary<Guid, VideoContent>();
                }

                return _AllVideoSnippets;
            }
        }

        public List<Guid> GetAllSnippetGuids()
        {
            return AllVideoSnippets.Keys.ToList();
        }

        public SimpleDreamerContentProvider()
        {
            nextSourceTimePoint = DateTime.Now;
        }

        public Guid AddVideoData(VideoContent newVideoSnippet)
        {
            Guid myNewGuid = Guid.NewGuid();

            if (TryRetryFailClass.TryRetryFail(3, () => AllVideoSnippets.TryAdd(myNewGuid, newVideoSnippet)))
            {
                return myNewGuid;
            }
            else
            {
                return Guid.NewGuid();
            }
        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public Stream GetSource(Guid id)
        {

#if COMMENT
            if (nextSourceTimePoint < DateTime.Now)
            {
                if (CurrentVideo >= FileList.Length)
                {
                    CurrentVideo = 0;
                }

                nextSourceTimePoint = DateTime.Now + TimeSpan.FromSeconds(30);
            }

            return System.IO.File.OpenRead(videoBasePath + FileList[CurrentVideo++]);
#endif
            //return AllVideoSnippets[id].VideoBinary;
            //MemoryStream ms = new MemoryStream();
            //var fromFile = System.IO.File.OpenRead(videoBasePath + FileList[0]);
            //fromFile.CopyTo(ms);
            return System.IO.File.OpenRead(videoBasePath + FileList[0]);//fromFile;//ms.ToArray();
        }
    }
}
