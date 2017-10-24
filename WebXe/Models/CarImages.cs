using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebXe.Models
{
    public class CarImages
    {
        public int Id { get; set; }
        
        [Required]
        public byte[] Image { get; set; }

        [Required]
        public int CarModelId { get; set; }
    }
}