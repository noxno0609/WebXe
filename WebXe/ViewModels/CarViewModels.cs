using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebXe.Models;

namespace WebXe.ViewModels
{
    public class CarViewModels
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int PricePublic { get; set; }
        public int CarType { get; set; }

        public IEnumerable<CarTypies> CarTypies { get; set; }

        [Required(ErrorMessage = "Xin chọn file.")]
        [Display(Name = "Chọn File")]
        public HttpPostedFileBase[] Images { get; set; }
    }
}