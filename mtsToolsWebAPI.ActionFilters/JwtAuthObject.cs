using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.ActionFilters
{
    public class JwtAuthObject
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }


        /// <summary>
        /// 口令过期时间
        /// 客户端过期时间为4小时
        /// 网页端过期时间为15分钟
        /// </summary>
        public string ExpiryDateTime { get; set; } = DateTime.UtcNow.AddHours(4).ToString();
    }
}
