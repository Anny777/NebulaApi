using System.Linq;
using NebulaApi.Models;
using System.Web.Http;
using NebulaApi.ViewModels;
using System.Web.Http.Cors;
using ProjectOrderFood.Enums;

namespace NebulaApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Dish")]
    public class DishController : ApiController
    {
        //public void SetToken(string token)
        //{
        //    Formula360Connection.SetToken(token);
        //}

        /// <summary>
        /// Получение списка блюд
        /// /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Waiter, Bartender, Cook, Admin")]
        [Route("List")]
        public IHttpActionResult List()
        {
            var db = new ApplicationDbContext();
            var response = db.Dishes.Select(c => new DishViewModel()
            {
                Id = c.Id,
                Name = c.name,
                Consist = c.Consist,
                Price = c.sellingPrice,
                Unit = c.Unit
            }).OrderBy(b => b.Name).ToList();
            return Json(response);
        }

        /// <summary>
        /// Смена состояния блюда на готовое
        /// </summary>
        /// <param name="id">идентификатор блюда</param>
        /// <param name="dishState">статус блюда</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin, Bartender, Cook, Waiter")]
        [Route("SetState")]
        public IHttpActionResult SetState(int id, DishState dishState)
        {
            try
            {
                var db = new ApplicationDbContext();
                var dish = db.CookingDishes.Find(id);
                if (dish == null)
                {
                    return BadRequest("Блюдо не найдено!");
                }
                dish.DishState = dishState;
                db.SaveChanges();
                return Ok(dish.Custom.ToViewModel());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Добавление блюда
        /// </summary>
        /// <param name="dish">объект блюда</param>
        /// <param name="idOrder">идентификатор заказа</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin, Bartender, Waiter")]
        [Route("AddDish")]
        public IHttpActionResult AddDish(DishViewModel dish, int idOrder)
        {
            try
            {
                var db = new ApplicationDbContext();
                var order = db.Customs.Find(idOrder);
                var currentDish = db.Dishes.Find(dish.Id);

                var newDish = new CookingDish()
                {
                    Dish = currentDish,
                    DishState = DishState.InWork,
                    IsActive = true
                };
                order.CookingDishes.Add(newDish);
                db.SaveChanges();

                return Ok(order.ToViewModel());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
