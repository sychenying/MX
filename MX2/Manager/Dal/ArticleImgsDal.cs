using MX2.Manager.Sys;
using MX2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MX2.Manager.Dal
{
    /// <summary>
    /// 文章/产品 子图片集合操作类
    /// </summary>
    public class ArticleImgsDal
    {
        public bool Add(ArticleImgs item)
        {
            string sqlstr = "INSERT INTO [tbl_ArticleImgs] ([Id] ,[AID] ,[Title] ,[ImgStr]) VALUES (null ,'" + item.AID + "','" + item.Title + "','" + item.ImgStr + "')";
            int res = DbHelperSQLite.ExecuteSql(sqlstr);
            return res > 0;
        }
        public bool Delete(long ID)
        {
            string sqlstr = "DELETE FROM [tbl_ArticleImgs] WHERE Id=" + ID;
            int res = DbHelperSQLite.ExecuteSql(sqlstr);
            return res > 0;
        }
        public bool Edit(ArticleImgs item)
        {
            string sqlstr = "UPDATE [tbl_ArticleImgs]  SET [AID] ='" + item.AID + "',[Title] = '" + item.Title + "',[ImgStr] = '" + item.ImgStr + "' WHERE id=" + item.ID;
            int res = DbHelperSQLite.ExecuteSql(sqlstr);
            return res > 0;
        }
        public ArticleImgs Find(long ID)
        {
            string sqlstr = "SELECT [Id] ,[AID] ,[Title] ,[ImgStr]  FROM [tbl_ArticleImgs] where Id=" + ID;
            DataSet ds = DbHelperSQLite.Query(sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                var res = ModelHelper.DataRowToModel<ArticleImgs>(ds.Tables[0].Rows[0]);
                return res;
            }
            else
            {
                return null;
            }
        }
        public List<ArticleImgs> FindAll()
        {
            string sqlstr = "SELECT [Id] ,[AID] ,[Title] ,[ImgStr] FROM [tbl_ArticleImgs]";
            DataSet ds = DbHelperSQLite.Query(sqlstr);
            List<ArticleImgs> list = new List<ArticleImgs>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                var res = (ds.Tables[0].Rows[0]);

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    var t = ModelHelper.DataRowToModel<ArticleImgs>(item);
                    list.Add(t);
                }
            }
            return list;
        }
        /// <summary>
        /// Article下所有图片
        /// </summary>
        /// <param name="AID"></param>
        /// <returns></returns>
        public List<ArticleImgs> FindAllByAID(long AID)
        {
            string sqlstr = "SELECT [Id] ,[AID] ,[Title] ,[ImgStr] FROM [tbl_ArticleImgs] where [AID]=" + AID;
            DataSet ds = DbHelperSQLite.Query(sqlstr);
            List<ArticleImgs> list = new List<ArticleImgs>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                var res = (ds.Tables[0].Rows[0]);

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    var t = ModelHelper.DataRowToModel<ArticleImgs>(item);
                    list.Add(t);
                }
            }
            return list;
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pagecount">总数量</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">每页数量</param>
        /// <returns></returns>
        public List<ArticleImgs> FindPaging(ref int pagecount, int pageindex, int pagesize)
        {
            //跳过个数
            int skipcount = pageindex > 0 ? (pageindex - 1) * pagesize : 0;
            string sqlstr = "SELECT [Id] ,[AID] ,[Title] ,[ImgStr] FROM [tbl_ArticleImgs] Limit " + pagesize + " Offset " + skipcount;
            DataSet ds = DbHelperSQLite.Query(sqlstr);
            List<ArticleImgs> list = new List<ArticleImgs>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                var res = (ds.Tables[0].Rows[0]);

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    var t = ModelHelper.DataRowToModel<ArticleImgs>(item);
                    list.Add(t);
                }
            }
            //总量
            string sqlstr2 = "SELECT count([Id]) FROM [tbl_ArticleImgs]";
            pagecount = Convert.ToInt32(DbHelperSQLite.GetSingle(sqlstr2));
            return list;
        }
    }
}