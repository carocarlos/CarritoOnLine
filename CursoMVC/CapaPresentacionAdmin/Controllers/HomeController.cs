using CapaPresentacionAdmin.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacionAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        public ActionResult Users()
        {
            DA_Users Data = new DA_Users();
            var GetUsers = Data.GetUsuarios();
            return View(GetUsers);
        }
    }
}