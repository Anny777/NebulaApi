using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using NebulaApi.Models;
using System.Web.Http;
using NebulaApi.ViewModels;
using ProjectOrderFood.Models;

namespace NebulaApi.Controllers
{
    //Get (api/value)
    public class DishController : ApiController
    {
        //public void SetToken(string token)
        //{
        //    Formula360Connection.SetToken(token);
        //}

        /// <summary>
        /// Получение списка блюд
        /// </summary>
        /// <returns></returns>
        [HttpGet]
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
    }
}
