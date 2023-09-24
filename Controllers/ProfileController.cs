using Crud_Operation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Crud_Operation.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserDetails(string username)
        {
            UserLogin uc = userDetails(username);

      
            return View(uc);


        }
        public static UserLogin userDetails(string username)
        {
            //UserLogin us = new UserLogin();
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0F29O5M\\SQLEXPRESS;Initial Catalog=CRUDDB;Integrated Security=True");
            try
            {
                UserLogin user = new UserLogin();
                conn.Open();
                SqlCommand cmd = new SqlCommand("UserData", conn);
                cmd.Parameters.Add(new SqlParameter("@username", username));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    user.name = Convert.ToString(sdr["name"]);
                    user.mob = sdr["mob"].ToString();
                    user.email = sdr["email"].ToString();
                    user.dob = sdr["dob"].ToString();
                    user.username = sdr["username"].ToString();
                    user.userrole = sdr["userrole"].ToString();
                }
                sdr.Close();
                return user;
            }catch(Exception ex)
            {
                throw ex;
            }
            finally { 
                conn.Close(); 
            }
        }

        public IActionResult UpdateData ()
        {
            return View(); 
        } 
        public void UpdateData1(UserClass uc)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0F29O5M\\SQLEXPRESS;Initial Catalog=CRUDDB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("UapdateData", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", uc.name);
            cmd.Parameters.AddWithValue("@mob", uc.mob);
            cmd.Parameters.AddWithValue("@email", uc.email);
            cmd.Parameters.AddWithValue("@dob", uc.dob);
            cmd.Parameters.AddWithValue("@username", uc.username);
            cmd.Parameters.AddWithValue("@password", uc.password);
            if (ConnectionState.Closed == conn.State)
            {
                conn.Open();
            }
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                conn.Close();
            }
        }

        public IActionResult ModifiedUsers()
        {
            return View();
        }
        public void Modified(UserClass uc)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0F29O5M\\SQLEXPRESS;Initial Catalog=CRUDDB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("DeleteData", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", uc.username);
            if (ConnectionState.Closed == conn.State)
            {
                conn.Open();
            }
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                conn.Close();
            }
        }
    }
}
