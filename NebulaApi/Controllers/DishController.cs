using System.Linq;
using NebulaApi.Models;
using System.Web.Http;
using NebulaApi.ViewModels;
using System.Web.Http.Cors;
using ProjectOrderFood.Enums;

namespace NebulaApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    //Get (api/value)
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
        [Authorize]
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
        public IHttpActionResult SetState(int id, DishState dishState)
        {
            var db = new ApplicationDbContext();
            var dish = db.CookingDishes.Find(id);
            if (dish == null)
            {
                return BadRequest("Блюдо не найдено!");
            }
            dish.DishState = dishState;
            db.SaveChanges();
            return Ok();
        }
    }
}
