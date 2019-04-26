using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.Common
{
    public class QueryObjectSpan
    {
        // 查询对象属性 / 列
        public object QueryAttribute { get; set; }
        // 起始范围
        public object StartMiniLimitValue { get; set; }
        // 结束范围
        public object EndMaxLimitValue { get; set; }
    }
}
