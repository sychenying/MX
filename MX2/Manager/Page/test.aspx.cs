using MX2.Manager.Dal;
using MX2.Manager.Sys;
using MX2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MX2.Manager.Page
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                load();
            }

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            LinksDal db = new LinksDal();
            Links item = new Links();
            item.Title = txt1.Text;
            item.LinkStr = txt2.Text;
            db.Add(item);

            load();
        }
        public void load()
        {
            LinksDal db = new LinksDal();
            grid.DataSource = db.FindAll();
            grid.DataBind();
        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            LinksDal db = new LinksDal();
            Links item = new Links();
            item.Title = txt1.Text;
            item.LinkStr = txt2.Text;
            item.ID = Convert.ToInt64(txtid.Text);
            db.Edit(item);
            load();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            LinksDal db = new LinksDal();
            var id = Convert.ToInt64(txtid.Text);
            db.Delete(id);
            load();
        }

        protected void btnfy_Click(object sender, EventArgs e)
        {
            int pageinde = Convert.ToInt32(txt1.Text);
            int pagesize = Convert.ToInt32(txt2.Text);
            int count = 0;
            LinksDal db = new LinksDal();
            grid2.DataSource = db.FindPaging(ref count, pageinde, pagesize);
            grid2.DataBind();
            Page.ClientScript.RegisterStartupScript(GetType(), "as", "alert('" + count + "')", true);
        }
    }
}