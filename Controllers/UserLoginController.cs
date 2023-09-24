using Crud_Operation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;


namespace Crud_Operation.Controllers
{
	public class UserLoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Login(UserLogin ul)
		{
			
			return View();

		}
        public IActionResult UserLogin(UserLogin ul)
        {
            UserLogin logdata = new UserLogin();
            logdata = userLogin(ul);
            if (logdata == null)
            {
                logdata.Status = 10;
            }
            else if (logdata.password == ul.password)
            {
                logdata.Status = 200;
				logdata.password = "";
            }
            else if (logdata.password != ul.password)
            {
                logdata.Status = 20;
            }
			else
			{
                logdata.Status = 21;
            }
			return Ok(logdata);

        }

        public static UserLogin userLogin(UserLogin ul)
		{
			UserLogin user = new UserLogin();
			SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0F29O5M\\SQLEXPRESS;Initial Catalog=CRUDDB;Integrated Security=True");
			try
			{
				SqlCommand cmd = new SqlCommand("UserData", conn);
				//cmd.Parameters.AddWithValue("@username", ul.username);
				cmd.Parameters.Add(new SqlParameter("@username", ul.username));

				cmd.CommandType = CommandType.StoredProcedure;
				conn.Open();
				SqlDataReader srd = cmd.ExecuteReader();
				while (srd.Read())
				{
					user.username = srd["username"].ToString(); //Convert.ToString(srd["username"]);

                    user.password = Convert.ToString(srd["password"]);
				}
				srd.Close();
				return user;
			}
			catch (Exception e)
			{
				throw e;
			}
			//finally
			//{
			//	conn.Close();
			//}
		}
	}
}
