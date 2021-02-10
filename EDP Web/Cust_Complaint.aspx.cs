using EDP_Web.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Web
{
    public partial class Cust_Complaint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            category.Items[0].Attributes["disabled"] = "disabled";
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            Service1Client client = new Service1Client();

            string cTitle = title.Text.Trim();
            string cCat = category.SelectedValue.Trim();
            string cBody = body.Text.Trim();

            int response = client.CreateComplaint(cTitle, cCat,cBody);

            if(response == 1)
            {
                Response.Redirect("Success.aspx");
            }
            
        }
    }
}