using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaMa.Framework.Web.Testsite.Models.BootstrapControls;

namespace LaMa.Framework.Web.Testsite.Controllers
{
    public class BootstrapControlsController : Controller
    {
        // GET: BootstrapControls
        public ActionResult Index()
        {
            var users = new List<User>();
            Random rnd = new Random();
            rnd.Next();
            for (int i = 0; i < 10; i++)
            {
                int id = rnd.Next();
                users.Add(new User
                          {
                              Id = id,
                              DateOfBirth = DateTime.Now,
                              Firstname = "Firstname " + id,
                              Lastname = "Lastname " + id,
                              IsPremium = rnd.Next(0,101)%2==0
                          });
            }
            var viewModel = new SimpleTableControlVM
                            {
                              Users = users
                            };
             
            return View(viewModel);
        }

        public JsonResult GetUsers()
        {
            var users = new List<User>();
            Random rnd = new Random();
            rnd.Next();
            for (int i = 0; i < 10; i++)
            {
                int id = rnd.Next();
                users.Add(new User
                {
                    Id = id,
                    DateOfBirth = DateTime.Now,
                    Firstname = "Firstname " + id,
                    Lastname = "Lastname " + id,
                    IsPremium = rnd.Next(0, 101) % 2 == 0
                });
            }
            return Json(users, JsonRequestBehavior.AllowGet);
        }
       
    }
}