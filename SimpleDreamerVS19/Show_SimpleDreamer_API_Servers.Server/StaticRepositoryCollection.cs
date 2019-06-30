using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Show_SimpleDreamer_API_Servers.Shared;

namespace Show_SimpleDreamer_API_Servers.Server
{
    public class StaticRepositoryCollections
    {
    }  

    internal static class EnumerableExtensions
    {
        public static ConcurrentDictionary<TKey, TValue> ToConcurrentDictionary<TKey, TValue>(this IEnumerable<TValue> source, Func<TValue, TKey> keySelector)
            => new ConcurrentDictionary<TKey, TValue>(source.Select(e => KeyValuePair.Create(keySelector(e), e)));
    }
}
