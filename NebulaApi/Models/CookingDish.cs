using NebulaApi.ViewModels;
using ProjectOrderFood.Enums;

namespace NebulaApi.Models
{
    public class CookingDish : ModelBase
    {
        public virtual Dish Dish { get; set; }
        public virtual DishState DishState { get; set; }
        public virtual Custom Custom { get; set; }
        public string Comment { get; set; }

        public static DishViewModel ToViewModel(Dish dish, CookingDish cookingDish)
        {
            return new DishViewModel()
            {
                Id = dish.Id,
                Name = dish.Name,
                Consist = dish.Consist,
                Price = dish.Price,
                Unit = dish.Unit,
                CookingDishId = cookingDish.Id,
                IsActive = cookingDish.IsActive,
                CreatedDate = cookingDish.CreatedDate,
                State = cookingDish.DishState,
                WorkshopType = dish.Category.WorkshopType
            };
        }
    }


}