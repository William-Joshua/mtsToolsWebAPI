using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.Model
{
    /// <summary>
    /// 用户账号
    /// </summary>
    public class UserAccountRequest
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginAccount { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string LoginPassword { get; set; }
    }
}
