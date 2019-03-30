using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.AOP
{
    // 缓存接口
    public interface ICaching
    {
        object Get(string cacheKey);

        void Set(string cacheKey, object cacheValue);
    }
}
