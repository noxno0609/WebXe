using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebXe.Models;
using WebXe.ViewModels;
using Microsoft.AspNet.Identity;

namespace WebXe.Controllers
{
    public class CarModelsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CarModelsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ActionResult Index(int id)
        {
            var model = _dbContext.CarModels.Find(id);
            return View(model);
        }

        public FileContentResult GetImage(int imageid)
        {
            CarImages images = _dbContext.CarImages.Where(n => n.Id == imageid).Single();
            try
            {
                return new FileContentResult(images.Image, "image/jpeg");
            }
            catch (Exception ex)
            {
            }
            return null;
        }
    }
}