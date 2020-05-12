using Jose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.Common.Security
{
    public class JwtAuthUtil
    {
        /// <summary>
        /// 令牌产生
        /// </summary>
        /// <returns></returns>
        public string GenerateToken()
        {
            string secret = "_itech_mts_Jwt_Secret ";//加解密的key,如果不一樣會無法成功解密
            Dictionary<string, Object> claim = new Dictionary<string, Object>();//payload 需透過token傳遞的資料
            claim.Add("Account", "mtsTools");
            claim.Add("Company", "ITECH ELECTRONIC CO.,LTD");
            claim.Add("Department", "Manufacturing");
            claim.Add("Exp", DateTime.Now.AddSeconds(Convert.ToInt32("3600")).ToString());//Token 時效設定100秒
            var payload = claim;
            var token = Jose.JWT.Encode(payload, Encoding.UTF8.GetBytes(secret), JwsAlgorithm.HS512);//產生token
            return token;
        }
    }
}
