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
    public partial class giohang : System.Web.UI.Page
    {
        string cnn = ConfigurationManager.ConnectionStrings["key"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string q = "select donhang.mahang,tenhang,mota,dongia,soluong,"
                    + "soluong*dongia as thanhtien from donhang,mathang " +
                    " where mathang.mahang=donhang.mahang";
                SqlDataAdapter da = new SqlDataAdapter(q, cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.GridView1.DataSource = dt;
                this.GridView1.DataBind();
                // tinh tong thanh tien: duyet data;
                double tong = 0;
                foreach(DataRow row in dt.Rows)
                {
                    double thanhtien = Convert.ToDouble(row["thanhtien"]);
                    tong = tong + thanhtien;
                }
                this.Label1.Text = "TONG THANH TIEN =" + tong + " DONG";
            }
            catch(SqlException err)
            {
                Response.Write(err.Message);
            }
        }
    }
}