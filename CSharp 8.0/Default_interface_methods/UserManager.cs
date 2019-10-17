
using System.Collections.Generic;

namespace Default_interface_methods
{
    interface ICache
    {
        void Add(string key, object item);
        object Get(string key);

        #region ICache version 2.0

        T Get<T>(string key) => (T)Get(key);

        void Add<T>(string key, T item)
        {
            Add(key, item);
        }

    #endregion
}

    public class InMemoryCache : ICache
    {
        private Dictionary<string, object> cache = new Dictionary<string, object>();

        public void Add(string key, object item)
        {
            cache[key] = item;
        }

        public object Get(string key)
        {
            return cache[key];
        }
    }
}
