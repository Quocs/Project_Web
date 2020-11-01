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
    public partial class Home_Admin : System.Web.UI.Page
    {
        ketnoi kn = new ketnoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                GridView1.DataSource = kn.laydata("select * from loaihang");
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox txtmaloai = (TextBox)GridView1.FooterRow.FindControl("TextBox4");
            TextBox txttenloai = (TextBox)GridView1.FooterRow.FindControl("TextBox5");
            string maloai = txtmaloai.Text;
            string tenloai = txttenloai.Text;
            int kq = kn.xuly("insert into loaihang values ('" + maloai + "'   ,   '" + tenloai + "')");
            if (kq > 0)
            {
                Response.Write("<script>alert('CAP NHAP THANH CONG');</script>");
                GridView1.DataSource = kn.laydata("select * from loaihang");
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('CAP NHAP KHONG THANH CONG');</script>");
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string maloai = e.Values["maloai"].ToString();
            int kq = kn.capnhap("delete from loaihang where maloai=" + maloai);
            if (kq > 0)
            {
                Response.Write("<script>alert('XOA THANH CONG');</script>");
                GridView1.DataSource = kn.laydata("select loaihang.* from loaihang");
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('XOA KHONG THANH CONG');</script>");
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = kn.laydata("select * from loaihang");
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            string maloai = e.NewValues["maloai"].ToString();
            string tenloai = e.NewValues["tenloai"].ToString();
            int kq = kn.capnhap("update loaihang set maloai= '" + maloai + "', tenloai='" + tenloai + "' where maloai='" + maloai + "'");
            if (kq > 0)
            {
                Response.Write("<script>alert('CAP NHAP THANH CONG');</script>");
                GridView1.DataSource = kn.laydata("select * from loaihang");
                GridView1.EditIndex = -1;
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('CAP NHAP KHONG THANH CONG');</script>");
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataSource = kn.laydata("select * from loaihang");
            GridView1.DataBind();
        }
    }
}