using MX2.Manager.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MX2.Manager.Ajax
{
    /// <summary>
    /// AjaxTool 的摘要说明
    /// </summary>
    public class AjaxTool : IHttpHandler
    {
        string result = "";//返回值
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var action = context.Request["action"];
            try
            {
                switch (action)
                {
                    case "DeleteLinksById":
                        DeleteLinksById();
                        break;
                    default:
                        err();
                        break;
                }
            }
            catch (Exception ex)
            {
                result = "err";
            }
            context.Response.Write(result);
        }

        private void DeleteLinksById()
        {
            long Id = Convert.ToInt64(HttpContext.Current.Request["LinksId"]);
            LinksDal db = new LinksDal();
            if (db.Delete(Id))
            {
                result = "OK";
            }
            else
            {
                result = "NO";
            }
        }
        private void err()
        {
            result = "";
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}