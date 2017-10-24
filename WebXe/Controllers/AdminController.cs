using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebXe.Models;
using WebXe.ViewModels;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.Data.Entity;
using System.Reflection;
using System.IO;

namespace WebXe.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        // GET: CarModels
        public AdminController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult DeleteCar(int id)
        {
            var model = _dbContext.CarModels.Find(id);

            _dbContext.CarModels.Remove(model);

            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Admin");
        }

        public ActionResult AddCar()
        {
            var viewModel = new CarViewModels
            {
                CarTypies = _dbContext.CarTypies.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddCar(CarViewModels viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.CarTypies = _dbContext.CarTypies.ToList();
                return View("AddCar", viewModel);
            }
            var model = new CarModels
            {
                CreatedUserId = User.Identity.GetUserId(),
                Content = viewModel.Content,
                Name = viewModel.Name,
                Price = viewModel.Price,
                PricePublic = viewModel.PricePublic,
                CarType = viewModel.CarType
            };

            _dbContext.CarModels.Add(model);
            _dbContext.SaveChanges();

            int count = 0;
            foreach (HttpPostedFileBase img in viewModel.Images)
            {
                //Checking file is available to save.  
                if (img != null)
                {
                    ++count;
                    MemoryStream target = new MemoryStream();
                    img.InputStream.CopyTo(target);
                    byte[] data = target.ToArray();

                    CarImages carImages = new CarImages()
                    {
                        Image = data,
                        CarModelId = model.Id
                    };
                    _dbContext.CarImages.Add(carImages);
                    _dbContext.SaveChanges();
                    //assigning file uploaded status to ViewBag for showing message to user.  
                }
            }

            return RedirectToAction("Index", "Admin");
        }

        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            var content = _dbContext.CarModels.ToList();
            return View(content);
        }

        [Authorize]
        public ActionResult EditCar(int id)
        {
            CarModels model = _dbContext.CarModels.Find(id);
            var viewModel = new CarViewModels
            {
                Id = model.Id,
                Content = model.Content,
                Price = model.Price,
                PricePublic = model.PricePublic,
                Name = model.Name,
                CarType = model.CarType,
                CarTypies = _dbContext.CarTypies.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditCar(CarViewModels viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.CarTypies = _dbContext.CarTypies.ToList();
                return View("EditCar", viewModel);
            }
            var model = _dbContext.CarModels.Find(viewModel.Id);
            model.Content = viewModel.Content;
            model.Name = viewModel.Name;
            model.Price = viewModel.Price;
            model.PricePublic = viewModel.PricePublic;
            model.CarType = viewModel.CarType;

            _dbContext.Entry(model).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Admin");
        }
    }
}