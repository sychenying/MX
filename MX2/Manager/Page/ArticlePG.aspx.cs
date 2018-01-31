using MX2.Manager.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MX2.Manager.Page
{
    public partial class ArticlePG : System.Web.UI.Page
    {
        ArticleDal db = new ArticleDal();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
                Bind();
        }
        private void Bind()
        {
            ColumnDal dblm = new ColumnDal();
            var list = dblm.FindAll();
            ddllm.DataSource = list;
            ddllm.DataValueField = "ID";
            ddllm.DataTextField = "Title";
            ddllm.DataBind();
            ListItem item1 = new ListItem();
            item1.Text = "请选择";
            item1.Value = "";
            ddllm.Items.Insert(0, item1);
            if (Request["type"] == "Edit")
            {
                long Id = Convert.ToInt64(Request["ID"]);
                var item = db.Find(Id);
                if (item != null)
                {
                    txtbt.Text = item.Title;
                    txtimg.Text = item.ImgStr;
                    txtbz.Text = item.ShortTxt;
                    txtnr.Text = item.Content;
                    ddllm.SelectedValue = item.CID.ToString();
                                      
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
                    item.ImgStr = txtimg.Text;
                    item.ShortTxt = txtbz.Text;
                    item.Content = txtnr.Text;
                    item.CID = Convert.ToInt64(ddllm.SelectedValue);
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
                Models.Article item = new Models.Article();
                item.Title = txtbt.Text;
                item.ImgStr = txtimg.Text;
                item.ProductTxt = "";
                item.ShortTxt = txtbz.Text;
                item.Content = txtnr.Text;
                item.AddTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                item.Clicks = 1;
                item.CID = Convert.ToInt64(ddllm.SelectedValue);


                if (db.Add(item))
                    Page.ClientScript.RegisterStartupScript(GetType(), "a1", "adOK()", true);
                else
                    Page.ClientScript.RegisterStartupScript(GetType(), "a2", "layer.alert('添加失败');", true);
            }
        }
    }
}