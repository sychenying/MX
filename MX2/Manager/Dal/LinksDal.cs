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
    /// 友情链接操作类
    /// </summary>
    public class LinksDal
    {
        public bool Add(Links item)
        {
            string sqlstr = "INSERT INTO [tbl_Links] ([Id] ,[Title] ,[LinkStr]) VALUES (null ,'" + item.Title + "','" + item.LinkStr + "')";
            int res = DbHelperSQLite.ExecuteSql(sqlstr);
            return res > 0;
        }
        public bool Delete(long ID)
        {
            string sqlstr = "DELETE FROM [tbl_Links] WHERE Id=" + ID;
            int res = DbHelperSQLite.ExecuteSql(sqlstr);
            return res > 0;
        }
        public bool Edit(Links item)
        {
            string sqlstr = "UPDATE [tbl_Links]  SET [Title] = '" + item.Title + "',[LinkStr] = '" + item.LinkStr + "' WHERE id=" + item.ID;
            int res = DbHelperSQLite.ExecuteSql(sqlstr);
            return res > 0;
        }
        public Links Find(long ID)
        {
            string sqlstr = "SELECT [Id],[Title],[LinkStr] FROM [tbl_Links] where Id=" + ID;
            DataSet ds = DbHelperSQLite.Query(sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                var res = ModelHelper.DataRowToModel<Links>(ds.Tables[0].Rows[0]);
                return res;
            }
            else
            {
                return null;
            }
        }
        public List<Links> FindAll()
        {
            string sqlstr = "SELECT [Id],[Title],[LinkStr] FROM [tbl_Links]";
            DataSet ds = DbHelperSQLite.Query(sqlstr);
            List<Links> list = new List<Links>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                var res = (ds.Tables[0].Rows[0]);

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    var t = ModelHelper.DataRowToModel<Links>(item);
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
        public List<Links> FindPaging(ref int pagecount, int pageindex, int pagesize)
        {
            //跳过个数
            int skipcount = pageindex > 0 ? (pageindex - 1) * pagesize : 0;
            string sqlstr = "SELECT [Id],[Title],[LinkStr] FROM [tbl_Links] Limit "+pagesize+" Offset "+skipcount;
            DataSet ds = DbHelperSQLite.Query(sqlstr);
            List<Links> list = new List<Links>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                var res = (ds.Tables[0].Rows[0]);

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    var t = ModelHelper.DataRowToModel<Links>(item);
                    list.Add(t);
                }
            }
            //总量
            string sqlstr2 = "SELECT count([Id]) FROM [tbl_Links]";
            pagecount = Convert.ToInt32(DbHelperSQLite.GetSingle(sqlstr2));
            return list;
        }
    }
}