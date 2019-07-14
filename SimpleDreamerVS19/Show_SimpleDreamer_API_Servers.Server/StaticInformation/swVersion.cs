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
            GitRevision = "git-09a3ffcf638d70075edcc40d4bf9973b7a6c9669";
            ApiVersion = "V0.1";
        }
    }

    public static class SwVersionProvider
    {
        public static swVersion Version = new swVersion();
    }
}
