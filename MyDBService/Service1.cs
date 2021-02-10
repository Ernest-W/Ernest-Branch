using MyDBService.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyDBService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
       
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public int CreateComplaint(string title, string category, string body)
        {
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            //this from web config
            string DBConnect = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            sqlStr.AppendLine("Insert INTO Complaints(title,category,body, status)");
            sqlStr.AppendLine("VALUES (@paraTitle,@paraCategory,@paraBody, @paraStatus)");
            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);

                sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

                sqlCmd.Parameters.AddWithValue("@paraTitle", title);
                sqlCmd.Parameters.AddWithValue("@paraCategory", category);
                sqlCmd.Parameters.AddWithValue("@paraBody", body);
                sqlCmd.Parameters.AddWithValue("@paraStatus", "Unresolved");

                myConn.Open();
                result = sqlCmd.ExecuteNonQuery();

                myConn.Close();
            }
            catch (Exception ex)
            {
                string err = ex.InnerException.Message;
            }

            return result;
        }

        public List<Complaints> GetAllComplaints()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            List<Complaints> complaints = new List<Complaints>();

            string DBConnect = DBConnect = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("select * from Complaints");

            SqlConnection myConn = new SqlConnection(DBConnect);

            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);

            da.Fill(ds, "TheTable");

            int rec_cnt = ds.Tables["TheTable"].Rows.Count;
            if (rec_cnt == 0)
            {
                complaints = null;
            }
            else
            {

                foreach (DataRow row in ds.Tables["TheTable"].Rows)
                {
                    int? custid = null;
                    if(row["customer_id"] != DBNull.Value)
                    {
                        custid = Convert.ToInt32(row["customer_id"]);
                    }
                    Complaints c = new Complaints();
                    c.title = Convert.ToString(row["title"]); 
                    c.customer_id = custid;
                    c.body = Convert.ToString(row["body"]); 
                    c.category = row["category"].ToString();
                    c.status = row["status"].ToString();
                    c.title_id = Convert.ToInt32(row["title_id"]);
                    complaints.Add(c);
                }
            }
            return complaints;
        }

        public int UpdateComplaintStatus(int title_id, string status)
        {
            int result = 0;
            string DBConnect = DBConnect = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            StringBuilder sqlStr = new StringBuilder();
            SqlCommand sqlCmd = new SqlCommand();
            sqlStr.AppendLine("update Complaints SET status=@status ");
            sqlStr.AppendLine("WHERE title_id=@title_id");


            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@title_id", title_id);
            sqlCmd.Parameters.AddWithValue("@status", status);
            

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();

            return result;
        }
    }
}
