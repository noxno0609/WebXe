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
        // GET: CarModels
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var viewModel = new CarViewModels
            {
                CarTypies = _dbContext.CarTypes.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Insert(CarViewModels viewModel)
        {
            var model = new CarModels
            {
                CreatedUserId = User.Identity.GetUserId(),
                Title = viewModel.Title,
                Content = viewModel.Content,
                Name = viewModel.Name,
                Price = viewModel.Price
            };
            _dbContext.CarModels.Add(model);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}