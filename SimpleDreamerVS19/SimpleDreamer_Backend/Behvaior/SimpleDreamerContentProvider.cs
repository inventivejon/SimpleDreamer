using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleDreamer_Backend.Behvaior
{
    public class SimpleDreamerContentProvider
    {
        const string videoBasePath = "./assets/Videos/";
        static readonly string[] FileList = { "file_example_MP4_640_3MG.mp4", "Aerial Shot Of Forest Covered In Snow.mp4", "Pexels Videos 2053855.mp4" };
        int CurrentVideo = 0;
        DateTime nextSourceTimePoint;

        public SimpleDreamerContentProvider()
        {
            nextSourceTimePoint = DateTime.Now;
        }

        public Stream GetSource()
        {
            if (nextSourceTimePoint < DateTime.Now)
            {
                if (CurrentVideo >= FileList.Length)
                {
                    CurrentVideo = 0;
                }

                nextSourceTimePoint = DateTime.Now + TimeSpan.FromSeconds(30);
            }

            return System.IO.File.OpenRead(videoBasePath + FileList[CurrentVideo++]);
        }
    }
}
