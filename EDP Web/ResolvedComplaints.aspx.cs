using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EDP_Web.ServiceReference1;

namespace EDP_Web
{
    public partial class ResolvedComplaints : System.Web.UI.Page
    {
        Service1Client client = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var data = client.GetAllComplaints();
                data = data.Where(x => x.status == "Resolved").ToArray();

                GridView1.DataSource = data;
                GridView1.DataBind();
            }
        }
    }
}