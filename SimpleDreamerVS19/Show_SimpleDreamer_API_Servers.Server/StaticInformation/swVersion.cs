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
            GitRevision = "git-7610a7d5685b7fd12efcf261d319cd125756afb0";
            ApiVersion = "V0.1";
        }
    }

    public static class SwVersionProvider
    {
        public static swVersion Version = new swVersion();
    }
}
