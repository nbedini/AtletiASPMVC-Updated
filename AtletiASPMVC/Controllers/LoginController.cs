using AtletiASPMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtletiASPMVC.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection connection;
        SqlCommand command;
        public string String { get; set; }

        public void GetConnectionString()
        {
            ConnectionStringSettingsCollection ConnectionString = ConfigurationManager.ConnectionStrings;
            String = ConnectionString["OlympicsEntitiesADONET"].ConnectionString;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserLoginData uld)
        {
            if (uld.Username != null && uld.Password != null)
            {
                GetConnectionString();
                using (connection = new SqlConnection(String))
                {
                    string query = "select * from Users where username = @username and password = @password";
                    connection.Open();
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", uld.Username);
                    command.Parameters.AddWithValue("@password", uld.Password);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        string UsernameDB = "";
                        string PasswordDB = "";
                        while (reader.Read())
                        {
                            UsernameDB = reader[0].ToString();
                            PasswordDB = reader[1].ToString();
                        }

                        if (uld.Username.Equals(UsernameDB) && uld.Password.Equals(PasswordDB))
                        {
                            return RedirectToAction("Index", "Athletes");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }

                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}