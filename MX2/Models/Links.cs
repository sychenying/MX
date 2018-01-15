using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MX2.Models
{
    /// <summary>
    /// 友情链接
    /// </summary>
    public class Links
    {
        public long ID { get; set; }
        /// <summary>
        /// 链接标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 链接字符串
        /// </summary>
        public string LinkStr { get; set; }
    }
}