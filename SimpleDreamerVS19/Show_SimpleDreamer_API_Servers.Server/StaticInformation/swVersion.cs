using System;
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
            GitRevision = "git-dd0b416ff52c1491aa9207af5c6ea3f897aa4e17";
            ApiVersion = "V0.1";
        }
    }

    public static class SwVersionProvider
    {
        public static swVersion Version = new swVersion();
    }
}
