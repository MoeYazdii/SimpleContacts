using SimpleContacts.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleContacts
{
    internal class ContactRepository : IContactsRepository
    {
        private string connectionStr = "Data Source=.;Initial Catalog=Contact_DB;" +
            "Integrated Security=true";
        public bool DeleteContacts(int contactID)
        {
            SqlConnection connection = new SqlConnection(connectionStr);
            try
            {
                string query = "Delete From MyContacts where ContactID=@ID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", contactID);
                connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool InsertContacts(string name, string family, string mobile, string email, int age, string address)
        {
            SqlConnection connection = new SqlConnection(connectionStr);
            try
            {
                string query = "insert into MyContacts (Name,Family,Email,Age,Mobile,Address) " +
                    "values(@Name,@Family,@Email,@Age" +
                    ",@Mobile,@Address)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Family", family);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Mobile", mobile);
                cmd.Parameters.AddWithValue("@Address", address);
                connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable Search(string Parameter)
        {
            string query = "select * from MyContacts where Name like @parameter or Family like @parameter;";
            SqlConnection cmd = new SqlConnection(connectionStr);
            SqlDataAdapter adapter = new SqlDataAdapter(query, cmd);
            adapter.SelectCommand.Parameters.AddWithValue("@parameter","%"+Parameter+"%");
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectAll()
        {
            string query = "select * from MyContacts";
            SqlConnection connection = new SqlConnection(connectionStr);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;

        }

        public DataTable SelectRow(int ContactID)
        {
            string query = "select * from MyContacts where ContactId=" + ContactID;
            SqlConnection connection = new SqlConnection(connectionStr);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool UpdateContacts(int contactID, string name, string family, string mobile, string email, int age, string address)
        {
            SqlConnection connection = new SqlConnection(connectionStr);
            try
            {
                string query = "update MyContacts set Name = @Name ,Family=@Family, Email=@Email," +
                    " Age=@Age, Mobile=@Mobile , Address = @Address " +
                    "where ContactID=@ID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@ID", contactID);
                cmd.Parameters.AddWithValue("@Family", family);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Mobile", mobile);
                cmd.Parameters.AddWithValue("@Address", address);
                connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
