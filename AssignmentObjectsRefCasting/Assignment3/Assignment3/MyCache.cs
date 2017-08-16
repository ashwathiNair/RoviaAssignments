using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class MyCache
    {
        private static Dictionary<string, object> _cache = new Dictionary<string, object>();

        public void Add(string key, object cacheItem)
        {
            _cache.Add(key, cacheItem);
        }

        public object this[string key]
        {
            get
            {
                if (_cache.ContainsKey(key))
                {
                    return _cache[key];
                }
                return null;
            }
        }

        public void Clear(string key)
        {
            _cache.Remove(key);
        }

        public object GetItem(string key)
        {
            if(_cache != null && _cache.ContainsKey(key))
            {
                return _cache[key];
            }
            return string.Format("Key not found: {0}", key);
        }

        public void Upsert(string key, object cacheItem)
        {
            if (_cache.ContainsKey(key))
            {
                _cache[key] = cacheItem;
            }
            else
            {
                this.Add(key, cacheItem); 
            }
        }
    }
}
