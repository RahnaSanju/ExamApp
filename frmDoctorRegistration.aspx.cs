using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamApp
{
    public partial class frmDoctorRegistration : System.Web.UI.Page
    {
        ConnectionCls objConCls = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string qry = "Select * from Dept_tab";
                DropDownList1.DataSource = objConCls.fn_Adapter(qry);
                DropDownList1.DataValueField = "dept_id";
                DropDownList1.DataTextField = "dept_name";
                DropDownList1.DataBind();
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string qry1 = "Select max(reg_id) from Login_tab";
            string regid = objConCls.fn_Scalar(qry1);
            int reg_id = 0;
            if (regid == "")
            {
                reg_id = 1;
            }
            else
            {
                int newRegid = Convert.ToInt32(regid);
                reg_id = newRegid + 1;
            }
            string ph = "~/PHS/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(ph));
            string insDoc = "Insert into Doc_Reg_Tab values(" + reg_id + "," + DropDownList1.SelectedItem.Value + ",'" + txtName.Text + "'," + txtAge.Text + ",'" + txtAddress.Text + "'," + txtPhone.Text + ",'" + ph + "')";
            int st = objConCls.fn_NonQuery(insDoc);
            if (st == 1)
            {
                string insLog = "Insert into Login_Tab values(" + reg_id + ",'" + txtUsername.Text + "','" + txtPassword.Text + "','doctor','active')";
                int st1 = objConCls.fn_NonQuery(insLog);
                if (st1 == 1)
                {
                    lblDisplay.Text = "Inserted";
                }
            }
        }
    }
}