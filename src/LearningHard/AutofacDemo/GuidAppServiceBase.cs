using System;
using System.Collections.Generic;
using System.Text;

namespace AutofacDemo
{
    public class GuidAppServiceBase : IGuidAppService
    {
        private readonly Guid _item;

        public GuidAppServiceBase()
        {
            _item = Guid.NewGuid();
        }

        public Guid GuidItem()
        {
            return _item;
        }
    }

    public class GuidTransientAppService : GuidAppServiceBase, IGuidTransientAppService
    {
    }

    public class GuidScopedAppService : GuidAppServiceBase, IGuidScopedAppService
    {
    }

    public class GuidSingletonAppService : GuidAppServiceBase, IGuidSingletonAppService
    {
    }

}
