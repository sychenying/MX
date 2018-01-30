using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MX2.Models
{
    /// <summary>
    /// 文章
    /// </summary>
    public class Article
    {
        public long ID { get; set; }
        /// <summary>
        /// 栏目ID
        /// </summary>
        public long CID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 主图片路径
        /// </summary>
        public string ImgStr { get; set; }
        /// <summary>
        /// 产品文本(可以标价,不为空就是产品)
        /// </summary>
        public string ProductTxt { get; set; }
        /// <summary>
        /// 短文本/备注/说明
        /// </summary>
        public string ShortTxt { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public string AddTime { get; set; }
        /// <summary>
        /// 点击量
        /// </summary>
        public long Clicks { get; set; }
        /// <summary>
        /// 栏目类型
        /// </summary>
        public string ColumnType { get; set; }
    }
}