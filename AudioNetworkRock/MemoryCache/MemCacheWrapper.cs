using System;
using System.Runtime.Caching;

namespace AudioNetworkRock.MemoryCache
{
    public class MemCacheWrapper : IMemoryCache
    {
        private readonly ObjectCache cache;

        public MemCacheWrapper(ObjectCache objectCache)
        {
            cache = objectCache ?? throw new ArgumentNullException("objectCache");
        }

        public void Add(string key, object value)
        {
            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(1.0),
                Priority = CacheItemPriority.NotRemovable
            };

            cache.Set(key, value, policy);
        }

        public bool Contains(string key)
        {
            return cache.Contains(key);
        }

        public object Get(string key)
        {
            return cache.Get(key);
        }
    }
}