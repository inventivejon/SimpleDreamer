﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Show_SimpleDreamer_API_Servers.Server.StaticInformation
{
    public class swVersion
    {
        public string SoftwareVersion { get; set; }
        public string GitRevision { get; set; }
        public string ApiVersion { get; set; }

        public swVersion()
        {
            SoftwareVersion = "V0.1";
            GitRevision = "git-9c3bea67c85db0bebc28e63b87bf27aef467a10d";
            ApiVersion = "V0.1";
        }
    }

    public static class SwVersionProvider
    {
        public static swVersion Version = new swVersion();
    }
}
