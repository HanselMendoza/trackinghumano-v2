using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using trackingentradaGrupoHumano.Models;

namespace trackingentradaGrupoHumano.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Inicio de sesion";

            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            DBENTRYTRAKYNGEntities db = new DBENTRYTRAKYNGEntities();
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                var user = db.loginusers.FirstOrDefault(e => e.email == email && e.contrasena == password);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.email, true);
                    return RedirectToAction("about", "home");

                }
                else
                {
                    return RedirectToAction("Index", new { Message = "valores incorrectos" });
                }

            }
            else
            {
                return RedirectToAction("Index",new { Message = "llenar lo campos para ingresar" });
            }




        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Contact");
        }
    }
}