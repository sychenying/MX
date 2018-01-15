using MX2.Manager.Sys;
using MX2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MX2.Manager.Dal
{
    public class ArticleDal
    {
        public bool Add(Article item)
        {
            string sqlstr = "INSERT INTO [tbl_Article] ([Id],[CID],[Title],[ImgStr],[ProductTxt],[ShortTxt],[Content],[AddTime],[Clicks]) VALUES (null ,'"+item.CID+"','" + item.Title + "','" + item.ImgStr + "','"+item.ProductTxt + "','"+item.ShortTxt+"','"+item.Content+"','"+item.AddTime+"','"+item.Clicks+"')";
            int res = DbHelperSQLite.ExecuteSql(sqlstr);
            return res > 0;
        }
        public bool Delete(long ID)
        {
            string sqlstr = "DELETE FROM [tbl_Article] WHERE Id=" + ID;
            int res = DbHelperSQLite.ExecuteSql(sqlstr);
            return res > 0;
        }
        public bool Edit(Article item)
        {
            string sqlstr = "UPDATE [tbl_Article]  SET [CID]='"+item.CID+"',[Title] = '" + item.Title + "',[ImgStr] = '" + item.ImgStr + "'," +
                "[ProductTxt]='"+item.ProductTxt+ "',[ShortTxt]='"+item.ShortTxt+ "',[Content]='"+item.Content + "'," +
                "[AddTime]='"+item.AddTime+ "',[Clicks]='"+item.Clicks + "'" +
                " WHERE id=" + item.ID;
            int res = DbHelperSQLite.ExecuteSql(sqlstr);
            return res > 0;
        }
        public Article Find(long ID)
        {
            string sqlstr = "SELECT [Id],[CID],[Title],[ImgStr],[ProductTxt],[ShortTxt],[Content],[AddTime],[Clicks] FROM [tbl_Article] where Id=" + ID;
            DataSet ds = DbHelperSQLite.Query(sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                var res = ModelHelper.DataRowToModel<Article>(ds.Tables[0].Rows[0]);
                return res;
            }
            else
            {
                return null;
            }
        }
        public List<Article> FindAll()
        {
            string sqlstr = "SELECT [Id],[CID],[Title],[ImgStr],[ProductTxt],[ShortTxt],[Content],[AddTime],[Clicks] FROM [tbl_Article]";
            DataSet ds = DbHelperSQLite.Query(sqlstr);
            List<Article> list = new List<Article>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                var res = (ds.Tables[0].Rows[0]);

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    var t = ModelHelper.DataRowToModel<Article>(item);
                    list.Add(t);
                }
            }
            return list;
        }
        /// <summary>
        /// 查询栏目下所有文章/产品
        /// </summary>
        /// <param name="pagecount">总数量</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="CID">栏目ID</param>
        /// <returns></returns>
        public List<Article> FindPagingListByCID(ref int pagecount, int pageindex, int pagesize,long CID)
        {
            //跳过个数
            int skipcount = pageindex > 0 ? (pageindex - 1) * pagesize : 0;
            string sqlstr = "SELECT [Id],[CID],[Title],[ImgStr],[ProductTxt],[ShortTxt],[AddTime],[Clicks] FROM [tbl_Article] where [CID]="+CID+" order by [Id] desc Limit " + pagesize + " Offset " + skipcount;
            DataSet ds = DbHelperSQLite.Query(sqlstr);
            List<Article> list = new List<Article>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                var res = (ds.Tables[0].Rows[0]);

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    var t = ModelHelper.DataRowToModel<Article>(item);
                    list.Add(t);
                }
            }
            //总量
            string sqlstr2 = "SELECT count([Id]) FROM [tbl_Article] where [CID]="+CID;
            pagecount = Convert.ToInt32(DbHelperSQLite.GetSingle(sqlstr2));
            return list;
        }
        /// <summary>
        /// 分页列表（无详情）
        /// </summary>
        /// <param name="pagecount">总数量</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">每页数量</param>
        /// <returns></returns>
        public List<Article> FindPagingList(ref int pagecount, int pageindex, int pagesize)
        {
            //跳过个数
            int skipcount = pageindex > 0 ? (pageindex - 1) * pagesize : 0;
            string sqlstr = "SELECT [Id],[CID],[Title],[ImgStr],[ProductTxt],[ShortTxt],[AddTime],[Clicks] FROM [tbl_Article] Limit " + pagesize + " Offset " + skipcount;
            DataSet ds = DbHelperSQLite.Query(sqlstr);
            List<Article> list = new List<Article>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                var res = (ds.Tables[0].Rows[0]);

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    var t = ModelHelper.DataRowToModel<Article>(item);
                    list.Add(t);
                }
            }
            //总量
            string sqlstr2 = "SELECT count([Id]) FROM [tbl_Article]";
            pagecount = Convert.ToInt32(DbHelperSQLite.GetSingle(sqlstr2));
            return list;
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pagecount">总数量</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">每页数量</param>
        /// <returns></returns>
        public List<Article> FindPaging(ref int pagecount, int pageindex, int pagesize)
        {
            //跳过个数
            int skipcount = pageindex > 0 ? (pageindex - 1) * pagesize : 0;
            string sqlstr = "SELECT [Id],[CID],[Title],[ImgStr],[ProductTxt],[ShortTxt],[Content],[AddTime],[Clicks] FROM [tbl_Article] Limit " + pagesize + " Offset " + skipcount;
            DataSet ds = DbHelperSQLite.Query(sqlstr);
            List<Article> list = new List<Article>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                var res = (ds.Tables[0].Rows[0]);

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    var t = ModelHelper.DataRowToModel<Article>(item);
                    list.Add(t);
                }
            }
            //总量
            string sqlstr2 = "SELECT count([Id]) FROM [tbl_Article]";
            pagecount = Convert.ToInt32(DbHelperSQLite.GetSingle(sqlstr2));
            return list;
        }
    }
}