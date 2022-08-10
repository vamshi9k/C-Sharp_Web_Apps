using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
        //ability to route HTTP requests
    {
        public ActionResult Index() {

            var Names = new List<string> { "neow","fella","skeeoosh"};

            return View(Names);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Seth Contact";

            return View();
        } 
    }
}