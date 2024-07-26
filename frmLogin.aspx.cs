using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamApp
{
    public partial class frmLogin : System.Web.UI.Page
    {
        ConnectionCls objConCls = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string qry = "Select count(reg_id) from Login_tab where username='"+txtUsername.Text+"' and password='"+txtPassword.Text+"'";
            string cid = objConCls.fn_Scalar(qry);
            if(cid!="")
            {
                Response.Redirect("frmOptions.aspx");
            }
            else
            {
                lblDisplay.Text = "Invalid Username or Password";
            }

        }
    }
}