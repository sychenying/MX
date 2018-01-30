using MX2.Manager.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MX2.Manager.Page
{
    public partial class ColumnPG : System.Web.UI.Page
    {
        ColumnDal db = new ColumnDal();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Bind();
        }
        private void Bind()
        {
            var list = db.FindAll();
            ddlflm.DataSource = list;
            ddlflm.DataValueField = "ID";
            ddlflm.DataTextField = "Title";
            ddlflm.DataBind();
            ListItem item1 = new ListItem();
            item1.Text = "请选择";
            item1.Value = "";
            ddlflm.Items.Insert(0, item1);
            if (Request["type"] == "Edit")
            {
                long Id = Convert.ToInt64(Request["ID"]);
                var item = db.Find(Id);
                if (item != null)
                {
                    txtbt.Text = item.Title;
                    txtorders.Text = item.Orders.ToString();
                    if (item.PID > 0)
                        ddlflm.SelectedValue = item.PID.ToString();
                    ddltype.SelectedValue = item.Type;
                }
                else
                {
                    //找不到数据就返回列表
                    Response.Redirect("ColumnListPG.aspx");
                }
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (Request["type"] == "Edit")
            {
                long Id = Convert.ToInt64(Request["ID"]);
                var item = db.Find(Id);
                if (item != null)
                {
                    item.Title = txtbt.Text;
                    item.Orders = Convert.ToInt32(txtorders.Text);
                    item.Type = ddltype.SelectedValue;
                    item.PID = ddlflm.SelectedValue != "" ? Convert.ToInt64(ddlflm.SelectedValue) : 0;
                    if (item.PID > 0)
                    {
                        var Pitem = db.Find(item.PID);
                        item.GID = Pitem.GID == 0 ? Pitem.ID : Pitem.GID;
                    }
                    else
                    {
                        item.GID = 0;
                    }

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
                Models.Column item = new Models.Column();
                item.Title = txtbt.Text;
                item.Orders = Convert.ToInt32(txtorders.Text);
                item.Type = ddltype.SelectedValue;
                item.PID = ddlflm.SelectedValue != "" ? Convert.ToInt64(ddlflm.SelectedValue) : 0;
                if (item.PID > 0)
                {
                    var Pitem = db.Find(item.PID);
                    item.GID = Pitem.GID == 0 ? Pitem.ID : Pitem.GID;
                }
                else
                {
                    item.GID = 0;
                }
                if (db.Add(item))
                    Page.ClientScript.RegisterStartupScript(GetType(), "a1", "adOK()", true);
                else
                    Page.ClientScript.RegisterStartupScript(GetType(), "a2", "layer.alert('添加失败');", true);
            }
        }
    }
}