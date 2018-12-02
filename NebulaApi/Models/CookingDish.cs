using NebulaApi.ViewModels;
using ProjectOrderFood.Enums;
using ProjectOrderFood.Models;

namespace NebulaApi.Models
{
    public class CookingDish : ModelBase
    {
        public virtual Dish Dish { get; set; }
        public virtual DishState DishState { get; set; }
        public virtual Custom Custom { get; set; }
        public string Comment { get; set; }

        public DishViewModel ToViewModel()
        {
            return new DishViewModel()
            {
                Id = Dish.Id,
                Name = Dish.name,
                Consist = Dish.Consist,
                Price = Dish.sellingPrice,
                Unit = Dish.Unit,
                CookingDishId = Id,
                IsActive = IsActive,
                CreatedDate = CreatedDate,
                State = DishState,
                WorkshopType = Dish.WorkshopType

            };
        }
    }


}