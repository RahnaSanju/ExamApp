using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamApp
{

    public partial class frmViewDocors : System.Web.UI.Page
    {
        ConnectionCls objConCls = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string qry = "Select * from Dept_tab";
                DropDownList1.DataSource = objConCls.fn_Adapter(qry);
                DropDownList1.DataValueField = "dept_id";
                DropDownList1.DataTextField = "dept_name";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "-Select-");
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string qry = "select drt.name,drt.age,drt.phone,drt.photo,dt.dept_name from Doc_Reg_Tab drt join Dept_tab dt on drt.Dept_Id=dt.Dept_Id where dt.Dept_Id=" + DropDownList1.SelectedItem.Value;
            DataList1.DataSource = objConCls.fn_Adapter(qry);
            DataList1.DataBind();


            GridView1.DataSource = objConCls.fn_Adapter(qry);
            GridView1.DataBind();
        }
    }
}