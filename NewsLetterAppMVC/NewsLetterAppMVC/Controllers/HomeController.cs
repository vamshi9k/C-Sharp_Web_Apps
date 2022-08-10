using NewsLetterAppMVC.Models;
using NewsLetterAppMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsLetterAppMVC.Controllers
{
    public class HomeController : Controller
    {

        //not needed when using entityFramework wrapper
        //private readonly string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Newsletter;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        [HttpPost]
        public ActionResult SignUp(string FirstName, string LastName, string Email) //uses model binding to get input parameters when method is called.
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(Email))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using ( var db = new NewsletterEntities())
                {
                    var signup = new SignUp();
                    signup.FirstName = FirstName;
                    signup.LastName = LastName;
                    signup.Email = Email;

                    db.SignUps.Add(signup);
                    db.SaveChanges();
                }

                //ADO.NET syntax
                ////save parameters to database
                ////server name string
                //string queryString = @"INSERT INTO SignUps (FirstName, LastName, Email)    
                //                    VALUES(@FirstName, @LastName, @Email)";
                //using (SqlConnection connection = new SqlConnection(connectionString))
                //{ //this is ADO.net syntax
                //    SqlCommand command = new SqlCommand(queryString, connection);
                //    command.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar);
                //    command.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar);
                //    command.Parameters.Add("@Email", System.Data.SqlDbType.VarChar);
                //    command.Parameters["@FirstName"].Value = FirstName;
                //    command.Parameters["@LastName"].Value = LastName;
                //    command.Parameters["@Email"].Value = Email;

                //    connection.Open();
                //    command.ExecuteNonQuery();
                //    connection.Close();
                //}

                return View("Success");
            }

        }

        public ActionResult Index()
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

    }// END HOMECONTROLLER
}