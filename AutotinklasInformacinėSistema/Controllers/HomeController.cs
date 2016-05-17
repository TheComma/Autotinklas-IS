using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutotinklasInformacinėSistema.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Login model = new Login();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Login model)
        {
            using (var db = new AutotinklasDBEntities()) { 
            var log = db.Login.Where(x => x.username == model.username).FirstOrDefault();
                if (log != null)
                {
                    if (log.password == model.password)
                    {
                        if (log.role == 0)
                        {
                            return RedirectToAction("MainRoot", "Home");
                        }
                        else if (log.role == 99)
                        {
                            return RedirectToAction("MainShop", "Home");
                        }
                        else
                        {
                            return RedirectToAction("MainUser", "Home");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", "Klaidingas vartotojo slaptažodis");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Klaidingas vartotojo slaptažodis");
                    return View(model);
                }
            }
            return View(model);
        }

        public ActionResult MainRoot()
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
    }
}