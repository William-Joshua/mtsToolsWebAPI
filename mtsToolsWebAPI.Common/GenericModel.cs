using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace mtsToolsWebAPI.Common
{
    /// <summary>
    /// 通用字段实体类
    /// </summary>
    public abstract class GenericModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string ID { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// 创建人
        /// </summary>
        [Required, StringLength(50)]
        public string CreateUser { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 修改人
        /// </summary>
        public string ModifyUser { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? ModifyTime { get; set; }
    }
}
