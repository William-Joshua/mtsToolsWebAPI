using System;
using System.Collections.Generic;
using System.Linq;
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
        private bool success = false;
        private string errorCode = "";

        /// <summary>
        /// Result Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Execute Result
        /// </summary>
        public bool Success { get { return success; } set { success = value; } }

        /// <summary>
        /// Result Error Code
        /// </summary>
        public string ErrorCode { get { return errorCode; } set { errorCode = value; } }

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
