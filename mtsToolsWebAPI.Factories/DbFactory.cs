using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mtsToolsWebAPI.EFCore.EntityFrameworkCore;

namespace mtsToolsWebAPI.Factories
{
    public class DbFactory : IDbFactory
    {
        EFCoreContext _efCoreContext;

        public EFCoreContext Init()
        {
            return _efCoreContext ?? (_efCoreContext = new EFCoreContext());
        }
    }
}
