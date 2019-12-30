using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryProject.Controllers
{
    public class HomeController : Controller
    {

        ApplicationDbContext _dbContextLivre;
        public HomeController ()
        {

           
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
           
                      
            return View();
        }

        public ActionResult About()
        {
           
           
            return View();
        }

        public ActionResult Contact()
        {
            
           

            return View();
        }
    }
}