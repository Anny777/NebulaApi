using System.Linq;
using NebulaApi.Models;
using System.Web.Http;
using NebulaApi.ViewModels;
using System.Web.Http.Cors;

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
        public IHttpActionResult List()
        /// </summary>
        /// <returns></returns>
        [HttpGet]
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
