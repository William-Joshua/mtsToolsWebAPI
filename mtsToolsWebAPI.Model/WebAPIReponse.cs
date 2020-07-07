using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.Model
{
    public class WebAPIReponse
    {
        public HttpStatusCode ReponseStatusCode { get; set; } = HttpStatusCode.OK;

        public string ReponseMessage { get; set; }

        public dynamic ResposeDataExtend { get; set; }
        
        public WebAPIReponse(HttpStatusCode statusCode, string reponseMsg)
        {
            this.ReponseStatusCode = statusCode;
            this.ReponseMessage = reponseMsg;
            this.ResposeDataExtend = null;
        }
        public WebAPIReponse(HttpStatusCode statusCode, string reponseMsg, string resposeData)
        {
            this.ReponseStatusCode = statusCode;
            this.ReponseMessage = reponseMsg;
            this.ResposeDataExtend = resposeData;
        }
        public WebAPIReponse(HttpStatusCode statusCode,string reponseMsg,Dictionary<string, dynamic> resposeData)
        {
            this.ReponseStatusCode = statusCode;
            this.ReponseMessage = reponseMsg;
            this.ResposeDataExtend = resposeData;
        }
    }
}
