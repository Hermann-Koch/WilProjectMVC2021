using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WilProjectMVC2021.Models;
using System.Data.SqlClient;

namespace WilProjectMVC2021.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlDataAdapter adapter = new SqlDataAdapter();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(Register register)
        {
            connectionString();
            con.Open();
            com.Connection = con;

            if (register.Email == null || register.Password == null)
            {
                return View("Register");
            }
            else
            {
                string sql = "INSERT INTO Users (Name, Cellphone, Email, Password, AccountType) VALUES ('" + register.Name + "','" + register.Cellphone + "','"
                    + register.Email + "','" + register.Password + "','" + "User" + "');";

                adapter.InsertCommand = new SqlCommand(sql, con);
                adapter.InsertCommand.ExecuteNonQuery();

                com.Dispose();
                con.Close();

                return View("Login");
            }

        }



        public ActionResult Login()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        void connectionString()
        {
            con.ConnectionString = @"Server=tcp:wilserver.database.windows.net,1433;Initial Catalog=WilProjectDB;Persist Security Info=False;User ID=WilAdmin;Password=WilProject1972;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        [HttpPost]
        public ActionResult Verify(Accounts acc)
        {
            //<form action="Verify" method="post" role="form">
            //Add this to the form on the view
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Users where Email='" + acc.Email + "' and Password='" + acc.Password + "'";
            dr = com.ExecuteReader();

            if (dr.Read())
            {
                con.Close();
                return Redirect("https://techspo.co/");
            }
            else
            {
                con.Close();
                return View("Login");
            }

        }
    }
}