using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MX2.Models
{
    /// <summary>
    /// 文章或者产品的图片集
    /// </summary>
    public class ArticleImgs
    {
        public long ID { get; set; }
        /// <summary>
        /// 产品ID
        /// </summary>
        public long AID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImgStr { get; set; }
    }
}