using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.Common
{
    /// <summary>
    /// Service Response Message
    /// </summary>
    [Serializable]
    public class ServiceResponse
    {
        /// <summary>
        /// Result Message
        /// </summary>
        public string Message { get; set; }

        private bool success = false;
        /// <summary>
        /// Execute Result
        /// </summary>
        public bool Success { get { return success; } set { success = value; } }

        private HttpStatusCode errorCode =  HttpStatusCode.OK;
        /// <summary>
        /// Result Error Code
        /// </summary>
        public HttpStatusCode ErrorCode { get { return errorCode; } set { errorCode = value; } }

        /// <summary>
        /// Return Result List
        /// </summary>
        public dynamic Results { get; set; }

        /// <summary>
        /// Result Total Counter
        /// </summary>
        public int TotalCount { get; set; }
    }
}
