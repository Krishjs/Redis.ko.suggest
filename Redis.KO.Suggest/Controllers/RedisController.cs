using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CityDataSource;
using Redis;

namespace RedisList.Web.Controllers
{
    public class RedisController : Controller
    {
        // GET: Redis
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCity(string name,int take,int skip)
        {            
            IEnumerable<City> city = RedisHelper.GetCityByCode(name).Skip(skip).Take(take);
            
            return Json(city.Select(c=>new { Id = c.Id,Code=c.Code, Name = c.Name  }),JsonRequestBehavior.AllowGet);
        }
    }
}