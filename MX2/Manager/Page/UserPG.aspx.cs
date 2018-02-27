using MX2.Manager.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MX2.Manager.Page
{
    public partial class UserPG : System.Web.UI.Page
    {
        UserDal db = new UserDal();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Bind();
        }
        private void Bind()
        {
            if (Request["type"] == "Edit")
            {
                long Id = Convert.ToInt64(Request["ID"]);
                var item = db.Find(Id);
                if (item != null)
                {
                    txtname.Text = item.UserName;
                    txtpwd.Text = item.PassWord;
                    txtzt.Text = item.States.ToString();
                }
                else
                {
                    //找不到数据就返回列表
                    Response.Redirect("LinksListPG.aspx");
                }
            }
        }
        //提交保存
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (Request["type"] == "Edit")
            {
                long Id = Convert.ToInt64(Request["ID"]);
                var item = db.Find(Id);
                if (item != null)
                {
                    item.UserName = txtname.Text;
                    item.PassWord = txtpwd.Text;
                    item.States =Convert.ToInt64(txtzt.Text);
                    if (db.Edit(item))
                        Page.ClientScript.RegisterStartupScript(GetType(), "e1", "edOK();", true);
                    else
                        Page.ClientScript.RegisterStartupScript(GetType(), "e2", "layer.alert('修改失败');", true);
                }
                else
                {
                    //找不到数据就返回列表
                    Response.Redirect("LinksListPG.aspx");
                }
            }
            else
            {
                Models.User item = new Models.User();
                item.UserName = txtname.Text;
                item.PassWord = txtpwd.Text;
                item.States = Convert.ToInt64(txtzt.Text);
                if (db.Add(item))
                    Page.ClientScript.RegisterStartupScript(GetType(), "a1", "adOK()", true);
                else
                    Page.ClientScript.RegisterStartupScript(GetType(), "a2", "layer.alert('添加失败');", true);
            }
        }
    }
}