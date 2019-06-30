using Show_SimpleDreamer_API_Servers.Shared;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Show_SimpleDreamer_API_Servers.Server.Manager
{
    public class PingStatsClass
    {
        public DateTime LastPing;
        public double LastPingInSeconds
        {
            get
            {
                return (DateTime.Now - LastPing).TotalSeconds;
            }
        }

        public PingStatsClass()
        {
            LastPing = DateTime.Now;
        }

        public void Ping()
        {
            LastPing = DateTime.Now;
        }
    }

    public class ExtendedBackendInformation
    {
        public BasicBackendInformation Basic;
        public PingStatsClass PingStats;

        public ExtendedBackendInformation(BasicBackendInformation basic)
        {
            Basic = basic;
            
        }

        public void Ping()
        {
            PingStats.Ping();
        }

        public PingStatsClass GetPingStats()
        {
            return PingStats;
        }
    }

    public class SimpleDreamerBackendRegistryClass
    {
        private ConcurrentDictionary<string, ExtendedBackendInformation> _allRegisteredBackends;
        private ConcurrentDictionary<string, ExtendedBackendInformation> AllRegisteredBackends
        {
            get
            {
                if(null == _allRegisteredBackends)
                {
                    _allRegisteredBackends = new ConcurrentDictionary<string, ExtendedBackendInformation>();
                }
                return _allRegisteredBackends;
            }
        }

        public List<BasicBackendInformation> GetAllBackends()
        {
            List<BasicBackendInformation> retVal = new List<BasicBackendInformation>();

            foreach (ExtendedBackendInformation singleExtendedInformation in AllRegisteredBackends.Values.ToList<ExtendedBackendInformation>())
            {
                retVal.Add(singleExtendedInformation.Basic);
            }

            return retVal;
        }

        public bool AddBackend(BasicBackendInformation newBackend)
        {
            if (!AllRegisteredBackends.ContainsKey(newBackend.IpAddress + ":" + newBackend.Port))
            {
                /* Entry does not exist yet */
                return AllRegisteredBackends.TryAdd(newBackend.IpAddress + ":" + newBackend.Port, new ExtendedBackendInformation(newBackend));
            }
            else
            {
                /* Entry already exists */
                AllRegisteredBackends[newBackend.IpAddress + ":" + newBackend.Port].Ping();
                return true;
            }
        }

        public void Ping(string backend)
        {
            if (AllRegisteredBackends.ContainsKey(backend))
            {
                /* Entry already exists */
                AllRegisteredBackends[backend].Ping();
            }
        }

        public bool RemoveBackend(string backend)
        {
            if (AllRegisteredBackends.ContainsKey(backend))
            {
                return AllRegisteredBackends.TryRemove(backend, out _);
            }
            else
            {
                /* Entry does not exists. Therefore -> Successfully deleted */
                return true;
            }
        }
    }
}
