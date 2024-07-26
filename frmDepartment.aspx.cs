using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamApp
{
    public partial class frmDepartment : System.Web.UI.Page
    {
        ConnectionCls objConCls = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string qry = "Insert into Dept_tab values('"+txtDeptName.Text+"')";
            int i = objConCls.fn_NonQuery(qry);
            if(i==1)
            {
                lblDisplay.Text = "Inserted";
                txtDeptName.Text = "";
            }
        }
    }
}