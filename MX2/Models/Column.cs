using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MX2.Models
{
    /// <summary>
    /// 栏目
    /// </summary>
    public class Column
    {
        public long ID { get; set; }
        /// <summary>
        /// 父ID
        /// </summary>
        public long PID { get; set; }
        /// <summary>
        /// 根ID
        /// </summary>
        public long GID { get; set; }
        /// <summary>
        /// 栏目标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 类型(文章、商品)
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 顺序
        /// </summary>
        public long Orders { get; set; }
    }
}