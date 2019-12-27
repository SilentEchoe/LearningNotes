using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.Common.MemoryCache
{
    // 缓存接口 待拓展
    public interface ICaching
    {
        object Get(string cacheKey);

        void Set(string cacheKey, object cacheValue);
    }
}
