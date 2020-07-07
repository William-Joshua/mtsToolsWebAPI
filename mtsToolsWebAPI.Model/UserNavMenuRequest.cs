using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.Model
{
    public class UserNavMenuRequest
    {
        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserAccount { get; set; }
        /// <summary>
        /// 用户角色
        /// </summary>
        public string UserRole { get; set; }
        /// <summary>
        /// 用户组
        /// </summary>
        public string UserGroup { get; set; }
        /// <summary>
        /// 登录平台
        /// </summary>
        public SoftPlatform LoginPlatform { get; set; } = SoftPlatform.thirdParty;
    }
}
