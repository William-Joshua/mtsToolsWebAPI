using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace mtsToolsWebAPI.EFCore
{
    /// <summary>
    /// 通用字段实体类
    /// </summary>
    public abstract class GenericModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string GenericModifyID { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// 创建人
        /// </summary>
        [Required, StringLength(50)]
        public string GenericModifyUser { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime GenericModifyTimestamp { get; set; } = DateTime.Now;
    }
}
