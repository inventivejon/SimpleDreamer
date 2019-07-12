using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIServer.StaticInformation
{
    public static class TryRetryFailClass
    {
        public delegate bool TryFunc();

        public static bool TryRetryFail(int retries, TryFunc thisFunction)
        {
            bool actionSucceeded = false;
            int tryCounter = 0;
             
            while((actionSucceeded == false) && (tryCounter < retries))
            {
                actionSucceeded = thisFunction();
                tryCounter++;
            }

            return actionSucceeded;
        }
    }
}
