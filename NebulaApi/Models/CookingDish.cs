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
    }
}