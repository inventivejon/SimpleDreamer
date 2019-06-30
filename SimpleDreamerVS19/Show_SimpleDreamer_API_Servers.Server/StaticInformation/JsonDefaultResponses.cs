using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Show_SimpleDreamer_API_Servers.Server.StaticInformation
{
    public class JsonSimpleSuccessOrFailed
    {
        public string Result { get; set; }

        public JsonSimpleSuccessOrFailed(string result)
        {
            this.Result = result;
        }
    }

    public static class JsonDefaultResponses
    {
        public static JsonSimpleSuccessOrFailed SimpleSuccess = new JsonSimpleSuccessOrFailed("Success");
        public static JsonSimpleSuccessOrFailed SimpleFailed = new JsonSimpleSuccessOrFailed("Failed");
    }
}
