using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebXe.Models
{
    public class CarModels
    {
        [Key]
        public int Id { get; set; }

        public ApplicationUser CreatedUser { get; set; }

        [Required]
        public string CreatedUserId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }
    }
}