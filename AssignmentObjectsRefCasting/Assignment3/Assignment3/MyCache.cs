using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class MyCache<T>
    {
        private static Dictionary<string, WeakReference> _cache = new Dictionary<string, WeakReference>();

        public void Add(string key, object cacheItem)
        {
            _cache.Add(key, new WeakReference(cacheItem));
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

        public void ClearAll()
        {
            _cache = new Dictionary<string, WeakReference>();
        }

        public T GetItem(string key)
        {
            if(_cache != null && _cache.ContainsKey(key))
            {
                return (T)_cache[key].Target;
            }
            //return default(T);
            throw new Exception("Key not found");
        }

        public void Upsert(string key, object cacheItem)
        {
            if (_cache.ContainsKey(key))
            {
                _cache[key] = new WeakReference(cacheItem);
            }
            else
            {
                this.Add(key, cacheItem); 
            }
        }
    }
}
