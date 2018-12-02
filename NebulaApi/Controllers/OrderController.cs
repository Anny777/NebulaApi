using NebulaApi.Models;
using NebulaApi.ViewModels;
using ProjectOrderFood.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace NebulaApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Order")]
    public class OrderController : ApiController
    {
        /// <summary>
        /// Получение заказа по номеру стола
        /// </summary>
        /// <param name="table">номер стола</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Waiter, Bartender, Cook, Admin")]
        [Route("GetOrder")]
        public IHttpActionResult GetOrder(int table)
        {
            var order = new ApplicationDbContext().Customs.FirstOrDefault(o => o.IsActive && o.IsOpened && o.TableNumber == table);

            if (order == null)
            {
                return Ok();
            }

            return Ok(order.ToViewModel());

        }

        /// <summary>
        /// Создание нового заказа; Дополнение существующего заказа; Запрос на удаление блюда;
        /// </summary>
        /// <param name="order">заказ</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Waiter, Admin")]
        [Route("New")]
        public IHttpActionResult New(OrderViewModel order)
        {
            if (order == null || order.Dishes == null)
            {
                return BadRequest("Не получены необходимые данные");
            }
            var db = new ApplicationDbContext();

            //// Новый заказ
            //if (order.Id <= 0)
            //{
            //var od = order.Dishes.Select(d => d.Id).Distinct().ToArray();
            //var dishes = db.Dishes.Where(c => od.Contains(c.Id)).ToList();
            var o = new Custom()
            {
                IsOpened = true,
                TableNumber = order.Table,
                CookingDishes = new List<CookingDish>()
            };
            db.Customs.Add(o);
            //}
            //else
            //{
            //    var newDishes = order.Dishes.Where(d => d.CookingDishId <= 0).ToArray();
            //    var od = newDishes.Select(d => d.Id).Distinct().ToArray();
            //    var custom = db.Customs.Find(order.Id);

            //    if (od.Count() > 0)
            //    {
            //        var dishes = db.Dishes.Where(c => od.Contains(c.Id)).ToArray();


            //        if (custom == null)
            //        {
            //            return BadRequest("Не найден заказ");
            //        }
            //        newDishes.Select(a => new CookingDish()
            //        {
            //            Comment = a.Comment,
            //            Dish = dishes.Single(c => c.Id == a.Id),
            //            DishState = DishState.InWork,
            //            CreatedDate = a.CreatedDate
            //        }).ToList().ForEach(custom.CookingDishes.Add);
            //    }

            //    // Запрос на удаление блюда из заказа (с помощью Except возвращает блюда, которым нужно сменить статус)
            //    var crd = custom.CookingDishes.Select(c => c.Id)
            //        .Except(order.Dishes.Where(c => c.CookingDishId > 0).Select(c => c.CookingDishId));

            //    db.CookingDishes.Where(c => crd.Contains(c.Id)).ToList()
            //        .ForEach(c => { c.DishState = DishState.CancellationRequested; });
            //}

            db.SaveChanges();
            return Ok(o.ToViewModel());
        }

        /// <summary>
        /// Получение открытых заказов (официант, кухня и бар будут брать блюда отсюда)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Waiter, Bartender, Cook, Admin")]
        [Route("List")]
        public IHttpActionResult List()
        {
            var db = new ApplicationDbContext();
            var orders = db.Customs.Where(c => c.IsOpened).ToList().Select(c => c.ToViewModel());
            return Ok(orders);
        }

        /// <summary>
        /// Закрытие заказа 
        /// </summary>
        /// <param name="tableNumber">номер стола</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Bartender, Admin")]
        [Route("Close")]
        public IHttpActionResult Close(int tableNumber)
        {
            var db = new ApplicationDbContext();
            db.Customs.Where(c => c.TableNumber == tableNumber && c.IsOpened).ToList().ForEach(c => { c.IsOpened = false; });

            db.SaveChanges();
            return Ok();
        }
    }
}
