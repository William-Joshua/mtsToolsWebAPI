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
        /// <summary>
        /// 登录平台
        /// Web API 支持第三方平台访问，如未指明平台默认第三方
        /// 不同平台访问权限存在差异
        /// </summary>
        public SoftPlatform LoginPlatform { get; set; } = SoftPlatform.thirdParty;
    }

   public enum SoftPlatform
    {
        mtsToolsStudio,
        mtsToolCaliburn,
        mtsToolLoggerCenter,
        mtsToolsSchedule,
        thirdParty
    }
}
