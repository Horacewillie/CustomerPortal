using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerPortal
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var connstring = ConfigurationManager.ConnectionStrings["customerportalconnstring"].ToString();
            var sqlconn = new SqlConnection(connstring);
            var sql = "select * from customers";
            var myCommand = new SqlCommand(sql, sqlconn);
            var data = new DataSet();
            sqlconn.Open();
            var adapter = new SqlDataAdapter(myCommand);
            adapter.Fill(data);
            dataTable.DataSource = data;
            dataTable.DataBind();

            var dataReader = myCommand.ExecuteReader();
            sqlconn.Close();

            
        }

        protected void button_Click(object sender, EventArgs e)
        {
            var connString = ConfigurationManager.ConnectionStrings["customerPortalConnString"].ToString();
            var sqlConn = new SqlConnection(connString);
            var sql = "insert into dbo.Customers (CustomerID, Name,  AccountNumber, Address, DateCreated) values (@i ,@n, @g, @a, @d)";

            try
            {
                var myCommand = new SqlCommand(sql, sqlConn);
                sqlConn.Open();
                myCommand.Parameters.AddWithValue("@i", id.Text);
                myCommand.Parameters.AddWithValue("@n", name.Text);
                myCommand.Parameters.AddWithValue("@g", account.Text);
                myCommand.Parameters.AddWithValue("@a", address.Text);
                myCommand.Parameters.AddWithValue("@d", DateTime.Now);
                int numOfAffectedRows = myCommand.ExecuteNonQuery();
                if (numOfAffectedRows > 0)
                {
                    result.InnerText = $"{numOfAffectedRows.ToString()}  rows affected successfully";
                }
                else
                {
                    result.InnerText = "No row to be affected";
                }
            }
            catch (Exception)
            {
                result.InnerText = "Error in handling result";
            }
            finally
            {
                sqlConn.Close();
            }

        }

        protected void Update(object sender, EventArgs e)
        {
            var connString = ConfigurationManager.ConnectionStrings["customerportalconnstring"].ToString();
            var sqlConn = new SqlConnection(connString);
            var sql = "update dbo.customers set address = @address" + "where name = @name";
            try
            {
                var myCommand = new SqlCommand(sql, sqlConn);
                myCommand.Parameters.Add(new SqlParameter("@address", address.Text));
                myCommand.Parameters.Add(new SqlParameter("@name", name.Text));
                sqlConn.Open();
                myCommand.ExecuteNonQuery();

                result.InnerText = "Updated Successfully";
            }
            catch (Exception)
            {
                result.InnerText = "Update Unsuccessful";

            }
        }
        protected void Delete(object sender, EventArgs e)
        {
            var connString = ConfigurationManager.ConnectionStrings["customerportalconnstring"].ToString();
            var sqlConn = new SqlConnection(connString);
            var sql = "delete from customers where name = @name";
            try
            {
                var myCommand = new SqlCommand(sql, sqlConn);
                myCommand.Parameters.Add(new SqlParameter("@name", name.Text));
                sqlConn.Open();
                myCommand.ExecuteNonQuery();
                result.InnerText = "Deleted Successfully";

            }
            catch (Exception)
            {

                result.InnerText = "Delete Unsuccessful";
            }
            finally
            {
                sqlConn.Close();
            }
        }
        protected void Clear(object sender, EventArgs e)
        {
            try
            {
                id.Text = "";
                name.Text = "";
                account.Text = "";
                address.Text = "";
                result.InnerText = "Cleared Successfully";
            }
            catch (Exception)
            {

                result.InnerText = "Cleared Unsuccessful";
            }
        }
    }
}