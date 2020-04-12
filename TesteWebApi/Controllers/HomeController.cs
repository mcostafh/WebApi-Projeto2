using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteWebApi.ViewModels;

namespace TesteWebApi.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login( Login login  )
        {
            Session["user"] = login.usuario;
            Session["psw"] = login.senha;
 

            return RedirectToAction("../Usuario/Index");
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
    }
}