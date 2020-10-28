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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        string cnn = ConfigurationManager.ConnectionStrings["key"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            try
            {
                string q = "select * from loaihang";
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string maloai = ((LinkButton)sender).CommandArgument;
            Context.Items["ml"] = maloai;
            Server.Transfer("sanpham.aspx");
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string ten = this.Login1.UserName;
            string matkhau = this.Login1.Password;
            string sql = "select * from khachhang where tendangnhap='" + ten + "' and matkhau='" + matkhau + "'";
            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(table);
            }
            catch(SqlException err)
            {
                Response.Write("<b>ERROR</b>" + err.Message + "</p>");

            }
            if (table.Rows.Count != 0)
            {
                Response.Cookies["tendangnhap"].Value = ten;
                Server.Transfer("sanpham.aspx");
            }
            else this.Login1.FailureText = "TEN DANG NHAP HAY MAT KHAU KHONG DUNG";
                
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("giohang.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Server.Transfer("giohang.aspx");
        }
    }
}