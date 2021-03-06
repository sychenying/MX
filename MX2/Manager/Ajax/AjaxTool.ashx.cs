﻿using MX2.Manager.Dal;
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
                    case "DeleteColumnById"://删除栏目
                        DeleteColumnById();
                        break;
                    case "DeleteArticleById":  // 删除文章/产品
                        DeleteArticleById();
                        break;
                    case "DeleteLinksById":// 删除友情链接
                        DeleteLinksById();
                        break;
                    case "DeleteUserById"://删除用户
                        DeleteUserById();
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
        //删除栏目
        private void DeleteColumnById()
        {
            long Id = Convert.ToInt64(HttpContext.Current.Request["ColumnId"]);
            ColumnDal db = new ColumnDal();
            int zlm = db.FindCountByPID(Id);
            ArticleDal db2 = new ArticleDal();
            int z2 = db2.FindCountByCID(Id);
            if (zlm == 0 && z2 == 0)//是否有子栏目或者文章/产品
            {
                if (db.Delete(Id))
                {
                    result = "OK";
                }
                else
                {
                    result = "NO";
                }
            }
            else
            {
                result = "NO";
            }

        }
        //删除文章/商品
        private void DeleteArticleById()
        {
            long Id = Convert.ToInt64(HttpContext.Current.Request["ArticleId"]);
            ArticleDal db = new ArticleDal();
            if (db.Delete(Id))
            {
                result = "OK";
            }
            else
            {
                result = "NO";
            }
        }
        //删除链接
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
        //删除用户
        private void DeleteUserById()
        {
            long Id = Convert.ToInt64(HttpContext.Current.Request["UserId"]);
            UserDal db = new UserDal();
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