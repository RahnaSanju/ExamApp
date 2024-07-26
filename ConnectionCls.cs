using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace ExamApp
{
    public class ConnectionCls
    {
        SqlConnection con;
        SqlCommand cmd;
        public ConnectionCls()
        {
            con = new SqlConnection(@"server=DESKTOP-8PBBHUD\SQLEXPRESS;database=ExamDB;integrated security=true");
        }
        public int fn_NonQuery(string qry)
        {
            cmd = new SqlCommand(qry, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public string fn_Scalar(string qry)
        {
            cmd = new SqlCommand(qry, con);
            con.Open();
            string val = cmd.ExecuteScalar().ToString();
            con.Close();
            return val;
        }
        public DataSet fn_Adapter(string qry)
        {
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

    }
}