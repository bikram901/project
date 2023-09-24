using Crud_Operation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Crud_Operation.Controllers
{
	public class SignUpController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}


		public void InsertRecord(UserClass uc)
		{
			string msg = "";
			try
			{

				SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0F29O5M\\SQLEXPRESS;Initial Catalog=CRUDDB;Integrated Security=True");
				SqlCommand cmd = new SqlCommand("InsertData", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@name", uc.name);
				cmd.Parameters.AddWithValue("@mob", uc.mob);
				cmd.Parameters.AddWithValue("@email", uc.email);
				cmd.Parameters.AddWithValue("@dob", uc.dob);
				cmd.Parameters.AddWithValue("@username", uc.username);
				cmd.Parameters.AddWithValue("@password", uc.password);
				cmd.Parameters.AddWithValue("@userrole", uc.userrole);
				if (ConnectionState.Closed == conn.State)
				{
					conn.Open();
				}

				int n = cmd.ExecuteNonQuery();
				if (n > 0)
				{
					msg = "Record saved into database";
				}
				else
				{
					msg = "Record not saved";
				}
			}
			catch (Exception ex)
			{
				msg = "Record not saved";
			}
		}
	}
}
