using NebulaApi.Models;
using NebulaApi.ViewModels;
using ProjectOrderFood.Enums;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace NebulaApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrderController : ApiController
    {
        /// <summary>
        /// Получение заказа по id
        /// </summary>
        /// <param name="id">идентификатор заказа</param>
        /// <returns></returns>
        public IHttpActionResult GetOrder(int id)
        {
            return Ok(new ApplicationDbContext().Customs.Find(id));
        }

        /// <summary>
        /// Создание нового заказа; Дополнение существующего заказа; Запрос на удаление блюда;
        /// </summary>
        /// <param name="order">заказ</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Waiter, Admin")]
        public IHttpActionResult New(OrderViewModel order)
        {
            if (order == null || order.Dishes == null)
            {
                return BadRequest("Не получены необходимые данные");
            }
            var db = new ApplicationDbContext();

            // Новый заказ
            if (order.Id <= 0)
            {
                var od = order.Dishes.Select(d => d.Id).Distinct().ToArray();
                var dishes = db.Dishes.Where(c => od.Contains(c.Id)).ToList();
                var o = new Custom()
                {
                    IsOpened = true,
                    TableNumber = order.Table,
                    CookingDishes = order.Dishes.Select(a => new CookingDish()
                    {
                        Comment = a.Comment,
                        Dish = dishes.Single(c => c.Id == a.Id),
                        DishState = DishState.InWork,
                        CreatedDate = a.CreatedDate
                    }).ToArray()
                };
                db.Customs.Add(o);
            }
            else
            {
                var newDishes = order.Dishes.Where(d => d.CookingDishId <= 0).ToArray();
                var od = newDishes.Select(d => d.Id).Distinct().ToArray();
                var custom = db.Customs.Find(order.Id);

                if (od.Count() > 0)
                {
                    var dishes = db.Dishes.Where(c => od.Contains(c.Id)).ToArray();


                    if (custom == null)
                    {
                        return BadRequest("Не найден заказ");
                    }
                    newDishes.Select(a => new CookingDish()
                    {
                        Comment = a.Comment,
                        Dish = dishes.Single(c => c.Id == a.Id),
                        DishState = DishState.InWork,
                        CreatedDate = a.CreatedDate
                    }).ToList().ForEach(custom.CookingDishes.Add);
                }

                // Запрос на удаление блюда из заказа (с помощью Except возвращает блюда, которым нужно сменить статус)
                var crd = custom.CookingDishes.Select(c => c.Id)
                    .Except(order.Dishes.Where(c => c.CookingDishId > 0).Select(c => c.CookingDishId));

                db.CookingDishes.Where(c => crd.Contains(c.Id)).ToList()
                    .ForEach(c => { c.DishState = DishState.CancellationRequested; });
            }

            db.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Получение открытых заказов (официант, кухня и бар будут брать блюда отсюда)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IHttpActionResult List()
        {
            var db = new ApplicationDbContext();
            var orders = db.Customs.Where(c => c.IsOpened).Select(c => new OrderViewModel()
            {
                Id = c.Id,
                Table = c.TableNumber,
                Dishes = c.CookingDishes.Where(a => a.DishState != DishState.Deleted).Select(b => new DishViewModel()
                {
                    Id = b.Dish.Id,
                    CookingDishId = b.Id,
                    Name = b.Dish.name,
                    Unit = b.Dish.Unit,
                    Consist = b.Dish.Consist,
                    Comment = b.Comment,
                    State = b.DishState,
                    Price = b.Dish.sellingPrice,
                    WorkshopType = b.Dish.WorkshopType,
                    CreatedDate = b.CreatedDate
                }),
                CreatedDate = c.CreatedDate
            });

            return Json(orders.ToArray());
        }

        /// <summary>
        /// Закрытие заказа 
        /// </summary>
        /// <param name="tableNumber">номер стола</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Bartender, Admin")]
        public IHttpActionResult Close(int tableNumber)
        {
            var db = new ApplicationDbContext();
            db.Customs.Where(c => c.TableNumber == tableNumber && c.IsOpened).ToList().ForEach(c => { c.IsOpened = false; });

            db.SaveChanges();
            return Ok();
        }
    }
}
