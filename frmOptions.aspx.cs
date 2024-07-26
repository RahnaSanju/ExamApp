using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamApp
{
    public partial class frmOptions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdminReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmAdmin_Reg_Form.aspx");
        }

        protected void btnInsDept_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmDepartment.aspx");
        }
    }
}