using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EAI.Template.Core.Cache
{

    public static class DistributedCacheExtensions
    {

        public static void SaveToCache<T>(this IDistributedCache cacheProvider, string key, T item, int expirationInMinutes)
        {
            var json = JsonSerializer.Serialize(item);

            cacheProvider.SetString(key, json, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(expirationInMinutes)
            });
        }

        public static T RetrieveFromCache<T>(this IDistributedCache cacheProvider, string key)
        {
            var json =  cacheProvider.GetString(key);

            return JsonSerializer.Deserialize<T>(json);
        }


       


    }
}
