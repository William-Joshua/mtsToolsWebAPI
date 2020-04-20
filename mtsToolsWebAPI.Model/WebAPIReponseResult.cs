using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.Model
{
    public class WebAPIReponseResult
    {
        public HttpStatusCode ReponseStausCode { get; set; } = HttpStatusCode.OK;

        public string ReponseMessage { get; set; }

        public Dictionary<string, dynamic> ResposeDataExtend { get; set; } = new Dictionary<string, dynamic>();
        
        public WebAPIReponseResult(HttpStatusCode statusCode, string reponseMsg)
        {
            this.ReponseStausCode = statusCode;
            this.ReponseMessage = reponseMsg;
            this.ResposeDataExtend = null;
        }

        public WebAPIReponseResult(HttpStatusCode statusCode,string reponseMsg,Dictionary<string, dynamic> resposeData)
        {
            this.ReponseStausCode = statusCode;
            this.ReponseMessage = reponseMsg;
            this.ResposeDataExtend = resposeData;
        }
    }
}
