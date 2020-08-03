using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.Model
{
    public class NavMenuBar
    {
        public List<NavMenuItem> Menu { get; set; } = new List<NavMenuItem>();
    }

    public class NavMenuItem
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string IconType { get; set; }
        public string Url { get; set; }
        public bool Master { get; set; }
        public bool SubArrow { get; set; }
        public List<NavSubMenuItem> Submenu { get; set; } = new List<NavSubMenuItem>();
    }

    public class NavSubMenuItem
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public bool Master { get; set; }
    }
}
