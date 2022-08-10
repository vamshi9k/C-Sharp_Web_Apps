using NewsLetterAppMVC.Models;
using NewsLetterAppMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsLetterAppMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            //ENTITY FRAMEWORK SYNTAX

            using (NewsletterEntities db = new NewsletterEntities())
            {
                //the lambda function:
                // filters out unsubcribed. making my edit useless.
                //var signups = db.SignUps.Where(x => x.Removed==null).ToList(); //ENtity Framework Object
                //LINQ implementation instead:
                var signups = (from c in db.SignUps
                               where c.Removed == null
                               select c).ToList();


                ////limit view with SignUpVM viewModel.
                var signupVMs = new List<SignUpVM>();
                foreach (var signup in signups)
                {

                    var signupVM = new SignUpVM();
                    signupVM.Id = signup.Id;
                    signupVM.FirstName = signup.FirstName;
                    signupVM.LastName = signup.LastName;
                    signupVM.Email = signup.Email;
                    signupVM.Removed = signup.Removed; //my code might break it.
                    signupVMs.Add(signupVM);
                }

                return View(signupVMs);
            }
        }
        public ActionResult Unsubscribe(int Id)
        {
            using(var db = new NewsletterEntities())
            {
                var signup = db.SignUps.Find(Id);
                signup.Removed = DateTime.Now;
                db.SaveChanges();
            }
            return RedirectToAction("Index"); //after removing, refresh view
            
        }
    } //end CLASS adminCOntroller
} //end namespace