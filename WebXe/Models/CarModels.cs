using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebXe.Models
{
    public class CarModels
    {
        public int Id { get; set; }

        public ApplicationUser CreatedUser { get; set; }

        [Required]
        public string CreatedUserId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int PricePublic { get; set; }

        [Required]
        public int CarType { get; set; }

        public List<CarImages> ListImages { get; set; }

        public void GetListImagesId()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            ListImages = db.CarImages.Where(n => n.CarModelId.Equals(Id)).ToList();
        }

        public string FormatType(int type)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var list = db.CarTypies.ToList();
            return list[type - 1].Name;
        }

        public string FormatMoney(int money)
        {
            return String.Format("{0:n0}", money);
        }

        public List<int> GeneratePaginationList(int index, int count)
        {
            List<int> result = new List<int>();
            if (index - 2 > 0)
                result.Add(index - 2);

            if (index - 1 > 0)
                result.Add(index - 1);

            result.Add(index);

            if (index + 1 <= count)
                result.Add(index + 1);

            if (index + 2 <= count)
                result.Add(index + 2);

            return result;
        }
    }
}