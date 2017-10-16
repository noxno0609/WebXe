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
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int CarType { get; set; }
        public List<CarTypes> CarTypies { get; set; }
    }
}