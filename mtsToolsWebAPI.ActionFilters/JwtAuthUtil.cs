
using Jose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace mtsToolsWebAPI.ActionFilters
{
    public class JwtAuthUtil
    {
        /// <summary>
        /// 令牌产生
        /// </summary>
        /// <returns></returns>
        public string GenerateToken(JwtAuthObject jwtAuthInfo)
        {

            string secretKey = WebConfigurationManager.AppSettings["JwtKeySecret"];


            var payload = jwtAuthInfo;
            var token = Jose.JWT.Encode(payload, Encoding.UTF8.GetBytes(secretKey), JwsAlgorithm.HS256);
            return token;
        }
    }
}
