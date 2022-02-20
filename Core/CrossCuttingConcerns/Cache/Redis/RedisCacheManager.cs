using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Core.Aspect.Cache;
using Microsoft.Extensions.Caching.Distributed;

namespace Core.CrossCuttingConcerns.Cache.Redis
{
    public class RedisCacheManager : ICacheManager
    {
        private readonly IDistributedCache _distributedCache;
        public RedisCacheManager(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        public T Get<T>(string key)
        {
            var data = _distributedCache.Get(key);
            var serializedList = Encoding.UTF8.GetString(data);
            var dataList = JsonSerializer.Deserialize<T>(serializedList);
            return dataList;

        }

        public object Get(string key)
        {
            var data = _distributedCache.Get(key);
            if (data != null)
            {
                var serializedList = Encoding.UTF8.GetString(data);
                var dataList = JsonSerializer.Deserialize<object>(serializedList);
                Debug.WriteLine(dataList);
                return dataList;

            }
            return null;
        }

        public void Add(string key, object value, int duration)
        {
            var serializedData = JsonSerializer.Serialize(value);
            var byteData = Encoding.UTF8.GetBytes(serializedData);
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddHours(duration))
                .SetSlidingExpiration(TimeSpan.FromMinutes(2));
            _distributedCache.Set(key, byteData, new DistributedCacheEntryOptions());
        }

        public bool IsAdd(string key)
        {
           var data= _distributedCache.Get(key);
           if (data != null)
           {
               return true;
           }

           return false;
        }

        public void Remove(string key)
        {
            _distributedCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            _distributedCache.Remove(pattern);
        }
    }
}
