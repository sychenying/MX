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
    /// 栏目图片/轮播图 操作类
    /// </summary>
    public class ColumnImgsDal
    {
        public bool Add(ColumnImgs item)
        {
            string sqlstr = "INSERT INTO [tbl_ColumnImgs] ([Id] ,[CID] ,[Title] ,[ImgStr] ,[ImgLink] ,[Orders]) VALUES (null ,'" + item.CID + "','" + item.Title + "','" + item.ImgStr + "','" + item.ImgLink + "','" + item.Orders + "')";
            int res = DbHelperSQLite.ExecuteSql(sqlstr);
            return res > 0;
        }
        public bool Delete(long ID)
        {
            string sqlstr = "DELETE FROM [tbl_ColumnImgs] WHERE Id=" + ID;
            int res = DbHelperSQLite.ExecuteSql(sqlstr);
            return res > 0;
        }
        public bool Edit(ColumnImgs item)
        {
            string sqlstr = "UPDATE [tbl_ColumnImgs]  SET [CID] ='" + item.CID + "',[Title] = '" + item.Title + "',[ImgStr] = '" + item.ImgStr + "',[ImgLink] ='" + item.ImgLink + "',[Orders] ='" + item.Orders + "' WHERE id=" + item.ID;
            int res = DbHelperSQLite.ExecuteSql(sqlstr);
            return res > 0;
        }
        public ColumnImgs Find(long ID)
        {
            string sqlstr = "SELECT [Id] ,[CID] ,[Title] ,[ImgStr] ,[ImgLink] ,[Orders] FROM [tbl_ColumnImgs] where Id=" + ID;
            DataSet ds = DbHelperSQLite.Query(sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                var res = ModelHelper.DataRowToModel<ColumnImgs>(ds.Tables[0].Rows[0]);
                return res;
            }
            else
            {
                return null;
            }
        }
        public List<ColumnImgs> FindAll()
        {
            string sqlstr = "SELECT [Id] ,[CID] ,[Title] ,[ImgStr] ,[ImgLink] ,[Orders] FROM [tbl_ColumnImgs]";
            DataSet ds = DbHelperSQLite.Query(sqlstr);
            List<ColumnImgs> list = new List<ColumnImgs>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                var res = (ds.Tables[0].Rows[0]);

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    var t = ModelHelper.DataRowToModel<ColumnImgs>(item);
                    list.Add(t);
                }
            }
            return list;
        }
        /// <summary>
        /// 栏目下所有图片集
        /// </summary>
        /// <param name="CID"></param>
        /// <returns></returns>
        public List<ColumnImgs> FindAllByCID(long CID)
        {
            string sqlstr = "SELECT [Id] ,[CID] ,[Title] ,[ImgStr] ,[ImgLink] ,[Orders] FROM [tbl_ColumnImgs] where [CID]=" + CID;
            DataSet ds = DbHelperSQLite.Query(sqlstr);
            List<ColumnImgs> list = new List<ColumnImgs>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                var res = (ds.Tables[0].Rows[0]);

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    var t = ModelHelper.DataRowToModel<ColumnImgs>(item);
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
        public List<ColumnImgs> FindPaging(ref int pagecount, int pageindex, int pagesize)
        {
            //跳过个数
            int skipcount = pageindex > 0 ? (pageindex - 1) * pagesize : 0;
            string sqlstr = "SELECT [Id] ,[CID] ,[Title] ,[ImgStr] ,[ImgLink] ,[Orders] FROM [tbl_ColumnImgs] Limit " + pagesize + " Offset " + skipcount;
            DataSet ds = DbHelperSQLite.Query(sqlstr);
            List<ColumnImgs> list = new List<ColumnImgs>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                var res = (ds.Tables[0].Rows[0]);

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    var t = ModelHelper.DataRowToModel<ColumnImgs>(item);
                    list.Add(t);
                }
            }
            //总量
            string sqlstr2 = "SELECT count([Id]) FROM [tbl_ColumnImgs]";
            pagecount = Convert.ToInt32(DbHelperSQLite.GetSingle(sqlstr2));
            return list;
        }
    }
}