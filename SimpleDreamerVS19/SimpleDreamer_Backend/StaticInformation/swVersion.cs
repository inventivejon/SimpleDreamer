using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleDreamer_Backend.StaticInformation
{
    public class swVersion
    {
        public string SoftwareVersion { get; set; }
        public string GitRevision { get; set; }
        public string ApiVersion { get; set; }

        public swVersion()
        {
            SoftwareVersion = "V0.1";
            GitRevision = "git-c20226c46b03ffb43dface9bdbc870e0fb5b9431";
            ApiVersion = "V0.1";
        }
    }

    public static class SwVersionProvider
    {
        public static swVersion Version = new swVersion();
    }
}
