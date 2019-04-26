using mtsToolsWebAPI.EFCore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.Factories
{
    public interface IDbFactory
    {
        EFCoreContext Init();
    }
}
