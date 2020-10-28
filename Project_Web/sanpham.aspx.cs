using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Project_Web
{
    public partial class sanpham : System.Web.UI.Page
    {
        string cnn = ConfigurationManager.ConnectionStrings["key"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            string q;
            if (Context.Items["ml"] == null)
                q = "select * from mathang";
            else
            {
                string maloai = Context.Items["ml"].ToString();
                q = "select * from mathang where maloai='" + maloai + "'";
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(q, cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.DataList1.DataSource = dt;
                this.DataList1.DataBind();
            }
            catch(SqlException err)
            {
                Response.Write(err.Message);
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string mahang = ((LinkButton)sender).CommandArgument;
            Context.Items["mh"] = mahang;
            Server.Transfer("chitiet.aspx");
        }
    }
}