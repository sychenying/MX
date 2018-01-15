using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MX2.Models
{
    /// <summary>
    /// 栏目图片/轮播图
    /// </summary>
    public class ColumnImgs
    {
        public long ID { get; set; }
        /// <summary>
        /// 栏目ID
        /// </summary>
        public int CID { get; set; }
        /// <summary>
        /// 图片标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImgStr { get; set; }
        /// <summary>
        /// 图片链接
        /// </summary>
        public string ImgLink { get; set; }
        /// <summary>
        /// 顺序
        /// </summary>
        public long Orders { get; set; }
    }
}