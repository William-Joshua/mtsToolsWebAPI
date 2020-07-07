using Jose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace mtsToolsWebAPI.ActionFilters
{    /// <summary>
     /// 身份认证拦截器
     /// </summary>
    public class JwtAuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            // TODO: key應該移至config
            var secret = WebConfigurationManager.AppSettings["JwtKeySecret"];

            if (actionContext.Request.Headers.Authorization == null || actionContext.Request.Headers.Authorization.Scheme != "Bearer")
            {
                setErrorResponse(actionContext, "Access Denied");
            }
            else
            {
                try
                {
                    var jwtObject = Jose.JWT.Decode<JwtAuthObject>(
                        actionContext.Request.Headers.Authorization.Parameter,
                        Encoding.UTF8.GetBytes(secret),
                        JwsAlgorithm.HS256);
                    if (jwtObject != null)
                    {
                        //判断口令过期时间
                        if (Convert.ToDateTime( jwtObject.ExpiryDateTime )< DateTime.Now)
                        {
                            setErrorResponse(actionContext, "Signature Timeout");
                        }
                    }
                }
                catch (Exception ex)
                {
                    setErrorResponse(actionContext, ex.Message);
                }
            }

            base.OnActionExecuting(actionContext);
        }

        private static void setErrorResponse(HttpActionContext actionContext, string message)
        {
            var response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, message);
            actionContext.Response = response;
        }
    }
}
