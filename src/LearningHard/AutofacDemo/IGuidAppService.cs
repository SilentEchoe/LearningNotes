using System;
using System.Collections.Generic;
using System.Text;

namespace AutofacDemo
{
    public interface IGuidAppService
    {
        Guid GuidItem();
    }

    public interface IGuidTransientAppService : IGuidAppService
    {
    }

    public interface IGuidScopedAppService : IGuidAppService
    {
    }

    public interface IGuidSingletonAppService : IGuidAppService
    {
    }
}
