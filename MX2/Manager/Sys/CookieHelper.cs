using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MX2.Manager.Sys
{
    /// <summary>
    /// Cookie处理类
    /// </summary>
    public class CookieHelper
    {
        public static string domain = "";

        /// <summary>
        /// 获取Cookie
        /// </summary>
        /// <param name="name">名称</param>
        public static HttpCookie Get(string name)
        {
            return HttpContext.Current.Request.Cookies[name];
        }

        /// <summary>
        /// 声明Cookie
        /// </summary>
        /// <param name="name">名称</param>
        public static HttpCookie Set(string name)
        {
            return new HttpCookie(name);
        }

        /// <summary>
        /// 移除Cookie
        /// </summary>
        /// <param name="name">名称</param>
        public static void Remove(string name)
        {
            Remove(Get(name));
        }

        /// <summary>
        /// 移除Cookie
        /// </summary>
        /// <param name="cookie">Cookie对象</param>
        public static void Remove(HttpCookie cookie)
        {
            if (cookie != null)
            {
                cookie.Expires = new DateTime(0x7bf, 5, 0x15);
                Save(cookie);
            }
        }

        /// <summary>
        /// 保存Cookie
        /// </summary>
        /// <param name="cookie">Cookie对象</param>
        public static void Save(HttpCookie cookie)
        {
            if (!string.IsNullOrEmpty(domain)) cookie.Domain = domain;
            cookie.Path = "/";
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 保存Cookie
        /// </summary>
        /// <param name="cookie">Cookie对象</param>
        /// <param name="day">保存天数</param>
        public static void Save(HttpCookie cookie, int day)
        {
            if (!string.IsNullOrEmpty(domain)) cookie.Domain = domain;
            cookie.Path = "/";
            cookie.Expires = DateTime.Now.AddDays(day);

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 根据Cookie名称获取相应Cookie值
        /// </summary>
        /// <param name="name">Cookie名称</param>
        /// <returns>Cookie值</returns>
        public static string GetValue(string name)
        {
            if (Get(name) != null)
                return HttpUtility.UrlDecode(Get(name).Value);

            return string.Empty;
        }

        /// <summary>
        /// 设置Cookie名称对应的Cookie值
        /// </summary>
        /// <param name="name">Cookie名称</param>
        /// <param name="value">Cookie值</param>
        public static void SetValue(string name, string value)
        {
            HttpCookie cookie = Set(name);
            cookie.Value = HttpUtility.UrlEncode(value);
            Save(cookie);
        }

        /// <summary>
        /// 设置Cookie名称对应的Cookie值
        /// </summary>
        /// <param name="name">Cookie名称</param>
        /// <param name="value">Cookie值</param>
        /// <param name="day">天数</param>
        public static void SetValue(string name, string value, int day)
        {
            HttpCookie cookie = Set(name);
            cookie.Value = HttpUtility.UrlEncode(value);
            cookie.Expires = DateTime.Now.AddDays(day);
            Save(cookie);
        }
    }
}