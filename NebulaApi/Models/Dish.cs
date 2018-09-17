using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NebulaApi.Controllers;
using ProjectOrderFood.Enums;
using ProjectOrderFood.Models;

namespace NebulaApi.Models
{
    public class Dish : DishBase
    {
        public int Id { get; set; }
        public virtual Category Category { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public string Consist { get; set; }
        public string Unit { get; set; }
        public bool IsAvailable { get; set; }
        public virtual WorkshopType WorkshopType {  get; set; }

    }
}