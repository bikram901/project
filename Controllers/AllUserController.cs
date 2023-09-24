using Crud_Operation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace Crud_Operation.Controllers
{
    public class AllUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Alluser()
        {
             
            return View();
        }
        public JsonResult Alluser1()
        {

            return Json(GetAll());
        }
        //public IActionResult Alluser1()
        //{
        //    List<UserClass> lst = GetAll();
        //    return View("~/Views/AllUser/Alluser.cshtml",lst);
        //}
        public List<UserClass> GetAll()
        {
            List<UserClass>lst = new List<UserClass>();
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0F29O5M\\SQLEXPRESS;Initial Catalog=CRUDDB;Integrated Security=True");
            
                SqlCommand cmd = new SqlCommand("SeletectData", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    lst.Add(new UserClass
                    {
                        name = rdr["name"].ToString(),
                        mob = rdr["mob"].ToString(),
                        email = rdr["email"].ToString(),
                        dob = rdr["dob"].ToString(),
                        username = rdr["username"].ToString(),
                        userrole = rdr["userrole"].ToString()
                    });

                }
                return lst;
               
            
        }
    }
}
