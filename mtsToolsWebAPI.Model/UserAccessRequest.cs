using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.Model
{
    public class UserAccessRequest
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 访问平台
        /// </summary>
        public string SoftPlatform { get; set; }
    }
}
