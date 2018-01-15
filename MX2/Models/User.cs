using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MX2.Models
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User
    {
        public long ID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 状态 1正常 0停用
        /// </summary>
        public long States { get; set; }
        
    }
}