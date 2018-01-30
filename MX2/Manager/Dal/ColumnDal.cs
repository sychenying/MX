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
    /// 栏目操作类
    /// </summary>
    public class ColumnDal
    {
        public bool Add(Column item)
        {
            string sqlstr = "INSERT INTO [tbl_Column] ([Id] ,[PID] ,[GID] ,[Title] ,[Type] ,[Orders]) VALUES (null ,'"+item.PID+"','"+item.GID+"','" + item.Title + "','" + item.Type + "','"+item.Orders+"')";
            int res = DbHelperSQLite.ExecuteSql(sqlstr);
            return res > 0;
        }
        public bool Delete(long ID)
        {
            string sqlstr = "DELETE FROM [tbl_Column] WHERE Id=" + ID;
            int res = DbHelperSQLite.ExecuteSql(sqlstr);
            return res > 0;
        }
        public bool Edit(Column item)
        {
            string sqlstr = "UPDATE [tbl_Column]  SET [PID]='"+item.PID+"',[GID]='"+item.GID+"',[Title] = '" + item.Title + "',[Type] = '" + item.Type + "',[Orders]='"+item.Orders+"' WHERE id=" + item.ID;
            int res = DbHelperSQLite.ExecuteSql(sqlstr);
            return res > 0;
        }
        public Column Find(long ID)
        {
            string sqlstr = "SELECT [Id] ,[PID] ,[GID] ,[Title] ,[Type] ,[Orders] FROM [tbl_Column] where Id=" + ID;
            DataSet ds = DbHelperSQLite.Query(sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                var res = ModelHelper.DataRowToModel<Column>(ds.Tables[0].Rows[0]);
                return res;
            }
            else
            {
                return null;
            }
        }
        public List<Column> FindAll()
        {
            string sqlstr = "SELECT [Id] ,[PID] ,[GID] ,[Title] ,[Type] ,[Orders] FROM [tbl_Column]";
            DataSet ds = DbHelperSQLite.Query(sqlstr);
            List<Column> list = new List<Column>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                var res = (ds.Tables[0].Rows[0]);

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    var t = ModelHelper.DataRowToModel<Column>(item);
                    list.Add(t);
                }
            }
            return list;
        }
        /// <summary>
        /// 查询该栏目下的子栏目
        /// </summary>
        /// <param name="PID"></param>
        /// <returns></returns>
        public List<Column> FindAllByPID(long PID)
        {
            string sqlstr = "SELECT [Id] ,[PID] ,[GID] ,[Title] ,[Type] ,[Orders] FROM [tbl_Column] where [PID]="+PID;
            DataSet ds = DbHelperSQLite.Query(sqlstr);
            List<Column> list = new List<Column>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                var res = (ds.Tables[0].Rows[0]);

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    var t = ModelHelper.DataRowToModel<Column>(item);
                    list.Add(t);
                }
            }
            return list;
        }
        /// <summary>
        /// 查询子栏目数量
        /// </summary>
        /// <param name="PID"></param>
        /// <returns></returns>
        public int FindCountByPID(long PID)
        {
            string sqlstr2 = "SELECT count([Id]) FROM [tbl_Column] where [PID]=" + PID;
            var res = Convert.ToInt32(DbHelperSQLite.GetSingle(sqlstr2));
            return res;
        }
        /// <summary>
        /// 查询该栏目下所有子 孙栏目
        /// </summary>
        /// <param name="GID"></param>
        /// <returns></returns>
        public List<Column> FindAllByGID(long GID)
        {
            string sqlstr = "SELECT [Id] ,[PID] ,[GID] ,[Title] ,[Type] ,[Orders] FROM [tbl_Column] where [GID]="+GID;
            DataSet ds = DbHelperSQLite.Query(sqlstr);
            List<Column> list = new List<Column>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                var res = (ds.Tables[0].Rows[0]);

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    var t = ModelHelper.DataRowToModel<Column>(item);
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
        public List<Column> FindPaging(ref int pagecount, int pageindex, int pagesize)
        {
            //跳过个数
            int skipcount = pageindex > 0 ? (pageindex - 1) * pagesize : 0;
            string sqlstr = "SELECT [Id] ,[PID] ,[GID] ,[Title] ,[Type] ,[Orders] FROM [tbl_Column] Limit " + pagesize + " Offset " + skipcount;
            DataSet ds = DbHelperSQLite.Query(sqlstr);
            List<Column> list = new List<Column>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                var res = (ds.Tables[0].Rows[0]);

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    var t = ModelHelper.DataRowToModel<Column>(item);
                    list.Add(t);
                }
            }
            //总量
            string sqlstr2 = "SELECT count([Id]) FROM [tbl_Column]";
            pagecount = Convert.ToInt32(DbHelperSQLite.GetSingle(sqlstr2));
            return list;
        }
    }
}