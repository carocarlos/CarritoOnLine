using CapaPresentacionAdmin.DataAccess;
using CapaPresentacionAdmin.Models;
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

        public ActionResult Users2()
        {    
            return View();
        }

        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            DA_Users Data = new DA_Users();
            var GetUsers = Data.GetUsuarios();
            return Json(new { data = GetUsers } , JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveUser(Usuario Objusuario)
        {
            DA_Users Data = new DA_Users();
            string vMessage;

            //Objusuario.Activo 
            var vResult = Data.SaveUser(Objusuario);
            if (vResult == "OK")
            {
                vMessage = "Usuario ingresado correctamente";
            }
            else
            {
                vMessage = "Se presentó un error. Por favor intente de nuevo";
            }

            return Json(new { data = vMessage }, JsonRequestBehavior.AllowGet);
        } 

    }
}