using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.Common
{
    public class QueryCondition<T> where T :class,new()
    {
        // 等于
        public Dictionary<object, object> EqualDictionary { get; set; }
        // 大于
        public Dictionary<object, object> MoreDictionary { get; set; }
        // 大于等于
        public Dictionary<object, object> MoreEqualDictionary { get; set; }
        // 小于
        public Dictionary<object, object> LessDictionary { get; set; }
        // 小于等于
        public Dictionary<object, object> LessEqualDictionary { get; set; }
        // 不等于
        public Dictionary<object, object> NonEqualDictionary { get; set; }
        // 模糊查询
        public Dictionary<object, object> FuzzyDictionary { get; set; }
        // 查询区间内
        public List<QueryObjectSpan> SpanDictionary { get; set; }
    }
}
