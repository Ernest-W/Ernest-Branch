using EDP_Web.ServiceReference1;using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Web
{
    public partial class CustServiceViewComplaint : System.Web.UI.Page
    {
        Service1Client client = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //Populating GridView from Database
                BindGrid();
            }
        }


        private void BindGrid()
        {

            var data = client.GetAllComplaints();
            data = data.Where(x => x.status != "Resolved").ToArray();

            DisplayComplaints.DataSource = data;
            DisplayComplaints.DataBind();

        }
        public List<Complaints> searchByTitle(List<Complaints> complaints)
        {
            complaints = complaints.Where(x => x.title == tbTitle.Text).ToList();
            return complaints;
        }

        public List<Complaints> searchByCategory(List<Complaints> complaints)
        {
            complaints = complaints.Where(x => x.status[0] == ddlComplaint.SelectedValue.ToString()[0]).ToList();
            return complaints;
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            var data = client.GetAllComplaints();
            data = data.Where(x => x.status != "Resolved").ToArray();
            List<Complaints> allComplaints = new List<Complaints>();
            foreach (var d in data)
            {

                Complaints c = new Complaints()
                {
                    title_id = d.title_id,
                    customer_id = d.customer_id,
                    title = d.title,
                    category = d.category,
                    body = d.body,
                   status = d.status
                };

                allComplaints.Add(c);
            }

            if(!string.IsNullOrEmpty(tbTitle.Text.Trim()))
            {
                allComplaints = searchByTitle(allComplaints);
            }

            allComplaints = searchByCategory(allComplaints);
            DisplayComplaints.DataSource = allComplaints;
            DisplayComplaints.DataBind();

        }

        protected void btnViewResolved_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResolvedComplaints.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = 0;
            GridViewRow row;
            GridView grid = sender as GridView;
            string command = e.CommandName;

            if (command == "SELECT")
            {
                index = Convert.ToInt32(e.CommandArgument);
                row = grid.Rows[index];

                // title_id
                string id = row.Cells[0].Text;
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DisplayComplaints.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DisplayComplaints.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // this is where the updating takes place
            string title_id = DisplayComplaints.Rows[e.RowIndex].Cells[0].Text;
            DropDownList ddl = (DropDownList)DisplayComplaints.Rows[e.RowIndex].FindControl("ddlRowStatus");
            string newstatus = ddl.SelectedValue;

            int result = client.UpdateComplaintStatus(Convert.ToInt32(title_id), newstatus);
            DisplayComplaints.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DropDownList ddl = (DropDownList)e.Row.FindControl("ddlRowStatus");
                Label lblStatus = (Label)e.Row.FindControl("lblRowStatus");
                ddl.SelectedValue = lblStatus.Text;
            }
        }
    }
}