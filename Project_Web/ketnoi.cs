using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace Project_Web
{
    
    public class ketnoi
    {
        SqlConnection con;
        private void layketnoi()
        {
           con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\EXERCISE\Project_Web\Project_Web\App_Data\Project.mdf;Integrated Security=True");
            con.Open();
        }
        private void dongketnoi()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
        public int capnhap(string sql)
        {
            int kq = 0;
            try
            {
                layketnoi();
                SqlCommand cmd = new SqlCommand(sql, con);
                kq = cmd.ExecuteNonQuery();
            }
            catch
            {
                kq = 0;
            }
            finally
            {
                dongketnoi();
            }
            return kq;
        }
        public DataTable laydata(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                layketnoi();
                SqlDataAdapter da = new SqlDataAdapter(sql,con);
                da.Fill(dt);
            }
            catch
            {
                dt = null;
            }
            finally
            {
                dongketnoi();
            }
            return dt;
        }
        public int xuly(string sql)
        {
            int kq = 0;
            try
            {
                layketnoi();
                SqlCommand cmd = new SqlCommand(sql, con);
                kq = cmd.ExecuteNonQuery();
            }
            catch
            {
                kq = 0;
                dongketnoi();
            }
            return kq;
        }
    }
}