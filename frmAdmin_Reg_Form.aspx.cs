using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamApp
{
    public partial class frmAdmin_Reg_Form : System.Web.UI.Page
    {
        ConnectionCls objConCls = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string qry = "Select max(reg_id) from Login_tab";
            string regid = objConCls.fn_Scalar(qry);
            int reg_id = 0;
            if (regid=="")
            {
                reg_id = 1;
            }
            else
            {
                int newRegid = Convert.ToInt32(regid);
                reg_id = newRegid + 1;
            }
            string insAd = "Insert into Admin_Reg_Tab values(" + reg_id + ",'" + txtName.Text + "','" + txtEmail.Text + "')";
            int st = objConCls.fn_NonQuery(insAd);
            if(st==1)
            {
                string insLog = "Insert into Login_Tab values("+reg_id+",'"+txtUsername.Text+"','"+txtPassword.Text+"','admin','active')";
                int st1=objConCls.fn_NonQuery(insLog);
                if(st1==1)
                {
                    lblDisplay.Text = "Inserted";
                }
            }

        }
    }
}