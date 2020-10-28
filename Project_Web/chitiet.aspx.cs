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
    public partial class chitiet : System.Web.UI.Page
    {
        string cnn = ConfigurationManager.ConnectionStrings["key"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            string q;
            if (Context.Items["mh"] == null)
                q = "select * from mathang";
            else
            {
                string mahang = Context.Items["mh"].ToString();
                q = "select * from mathang where mahang='" + mahang + "'";
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button mua = (Button)sender;
            string mahang = mua.CommandArgument.ToString();//LAY BIEN ARGUMET O BUTTON
            DataListItem item = (DataListItem)mua.Parent;
            string soluong = ((TextBox)item.FindControl("TextBox1")).Text;
            if (Request.Cookies["tendangnhap"] == null) return;//CHUA DANG NHAP THI KHONG LAM GI
            string ten = Request.Cookies["tendangnhap"].Value;
            SqlConnection con = new SqlConnection(cnn);
            con.Open();
            string query = "select * from donhang " + "where tendangnhap='" + ten + "' and mahang='" + mahang + "'";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();//THUC THI CAU LENH SQL
            if (reader.Read())
            {
                reader.Close();
                command = new SqlCommand(
                 "update donhang set soluong=soluong+" + soluong
                 + "where tendangnhap='" + ten + "' and mahang='" + mahang + "'", con
                    );
            }
            else
            {
                reader.Close();
                command = new SqlCommand(
                    "insert into donhang" + "(tendangnhap,mahang,soluong) values('" +
                    ten + "','" + mahang + "'," + soluong + ")", con
                    );

            }
            command.ExecuteNonQuery();
            con.Close();
        }

        
    }
}