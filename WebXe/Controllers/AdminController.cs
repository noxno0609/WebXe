using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebXe.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Xe()
        {
            return View();
        }

        public ActionResult Themmoixe()
        {
            return View();
        }

        public ActionResult Chinhsua()
        {
            return View();
        }
    }
}