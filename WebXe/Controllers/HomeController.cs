using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebXe.Models;

namespace WebXe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public FileContentResult GetImage(int id, int indexa)
        {
            List<CarImages> list = _dbContext.CarImages.Where(n => n.CarModelId.Equals(id)).ToList();
            try
            {
                return new FileContentResult(list[indexa].Image, "image/jpeg");
            }
            catch(Exception ex)
            {
            }
            return null;
        }

        public ActionResult Index(int id = 1)
        {
            var content = _dbContext.CarModels.ToList();

            int countPage = Convert.ToInt32(Math.Ceiling((double)content.Count / 5));
            if (countPage == 0)
                countPage = 1;

            if (id <= 0)
                id = 1;
            else if (id >= countPage)
                id = countPage;

            ViewBag.NowPage = id;
            ViewBag.CountPage = countPage;

            List<CarModels> viewContent = new List<CarModels>();
            for (int i = id*5-5; i<id*5; i++)
            {
                try
                {
                    viewContent.Add(content[i]);
                }
                catch(Exception ex)
                {
                }
            }

            return View(viewContent);
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