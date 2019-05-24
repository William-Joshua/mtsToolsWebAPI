using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.Model
{
    public class UserMenuItem
    {
        public string MenuID { get; set; }
        public string MenuName { get; set; }
        public string MenuTitle { get; set; }
        public string MenuParentID { get; set; }
        public string MenuGroup { get; set; }
        public string MenuComponent { get; set; }
        public string MenuIcon { get; set; }
        public int? MenuWeight { get; set; }
    }
}
