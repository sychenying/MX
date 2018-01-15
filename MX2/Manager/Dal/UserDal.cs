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
    /// 用户操作类
    /// </summary>
    public class UserDal
    {
        public bool Login(string UserName, string PassWord)
        {
            var pwd = SysConstant.GetMD5(PassWord);//密码加密
            string sqlstr = "SELECT count([Id]) FROM [tbl_User] where [UserName]=" + UserName + " and [PassWord]=" + pwd;
            int res = Convert.ToInt32(DbHelperSQLite.GetSingle(sqlstr));
            return res > 0;
        }

        public bool Add(User item)
        {
            var pwd = SysConstant.GetMD5(item.PassWord);//密码加密
            string sqlstr = "INSERT INTO [tbl_User] ([Id] ,[UserName] ,[PassWord],[States]) VALUES (null ,'" + item.UserName + "','" + pwd + "','" + item.States + "')";
            int res = DbHelperSQLite.ExecuteSql(sqlstr);
            return res > 0;
        }
        public bool Delete(long ID)
        {
            string sqlstr = "DELETE FROM [tbl_User] WHERE Id=" + ID;
            int res = DbHelperSQLite.ExecuteSql(sqlstr);
            return res > 0;
        }
        public bool Edit(User item)
        {
            var pwd = SysConstant.GetMD5(item.PassWord);//密码加密
            string sqlstr = "UPDATE [tbl_User]  SET [UserName] = '" + item.UserName + "',[PassWord] = '" + pwd + "',[States]='" + item.States + "' WHERE id=" + item.ID;
            int res = DbHelperSQLite.ExecuteSql(sqlstr);
            return res > 0;
        }
        public bool EditPassWord(User item)
        {
            var pwd = SysConstant.GetMD5(item.PassWord);//密码加密
            string sqlstr = "UPDATE [tbl_User]  SET [PassWord] = '" + pwd + "' WHERE id=" + item.ID;
            int res = DbHelperSQLite.ExecuteSql(sqlstr);
            return res > 0;
        }
        public User Find(long ID)
        {
            string sqlstr = "SELECT [Id],[UserName],[PassWord],[States] FROM [tbl_User] where Id=" + ID;
            DataSet ds = DbHelperSQLite.Query(sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                var res = ModelHelper.DataRowToModel<User>(ds.Tables[0].Rows[0]);
                return res;
            }
            else
            {
                return null;
            }
        }
        public List<User> FindAll()
        {
            string sqlstr = "SELECT [Id],[UserName],[PassWord],[States] FROM [tbl_User]";
            DataSet ds = DbHelperSQLite.Query(sqlstr);
            List<User> list = new List<User>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                var res = (ds.Tables[0].Rows[0]);

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    var t = ModelHelper.DataRowToModel<User>(item);
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
        public List<User> FindPaging(ref int pagecount, int pageindex, int pagesize)
        {
            //跳过个数
            int skipcount = pageindex > 0 ? (pageindex - 1) * pagesize : 0;
            string sqlstr = "SELECT [Id],[UserName],[PassWord],[States] FROM [tbl_User] Limit " + pagesize + " Offset " + skipcount;
            DataSet ds = DbHelperSQLite.Query(sqlstr);
            List<User> list = new List<User>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                var res = (ds.Tables[0].Rows[0]);

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    var t = ModelHelper.DataRowToModel<User>(item);
                    list.Add(t);
                }
            }
            //总量
            string sqlstr2 = "SELECT count([Id]) FROM [tbl_User]";
            pagecount = Convert.ToInt32(DbHelperSQLite.GetSingle(sqlstr2));
            return list;
        }
    }
}