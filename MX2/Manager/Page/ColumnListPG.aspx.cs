﻿using MX2.Manager.Dal;
using MX2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MX2.Manager.Page
{
    public partial class ColumnListPG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
                Bind();
        }
        private void Bind()
        {
            int pageindex = Convert.ToInt32(Request["page"]);
            int pagesize = Convert.ToInt32(Request["pagesize"]) == 0 ? 10 : Convert.ToInt32(Request["pagesize"]);
            int pagecount = 0;
            List<Column> list = new List<Column>();
            ColumnDal db = new ColumnDal();
            list = db.FindPaging(ref pagecount, pageindex, pagesize);
            hfcount.Value = pagecount.ToString();
            rptlist.DataSource = list;
            rptlist.DataBind();
        }
    }
}