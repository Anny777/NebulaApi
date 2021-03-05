using Microsoft.AspNet.Identity.EntityFramework;
using NebulaApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NebulaApi.Models
{
    public class Custom : ModelBase
    {
        public Custom()
        {
            CookingDishes = new List<CookingDish>();
        }

        public virtual ICollection<CookingDish> CookingDishes { get; set; }

        public bool IsOpened { get; set; }
        public virtual ApplicationUser User { get; set; }
        public bool IsExportRequested { get; set; }
        public int TableNumber { get; set; }
        public string Comment { get; set; }

        public static OrderViewModel ToViewModel(Custom custom, CookingDish[] cookingDishes)
        {
            return new OrderViewModel()
            {
                Id = custom.Id,
                Table = custom.TableNumber,
                Dishes = cookingDishes.Select(c => CookingDish.ToViewModel(c.Dish, c)).ToArray(),
                CreatedDate = custom.CreatedDate,
                Comment = custom.Comment,
                IsExportRequested = custom.IsExportRequested,
                CurrentMemory = (GC.GetTotalMemory(false) / 1024 / 1024).ToString(),
                TotalMemory = (Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024).ToString()
            };
        }
    }
}