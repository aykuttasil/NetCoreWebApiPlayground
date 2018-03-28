using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebApiPlayground.Models;

namespace NetCoreWebApiPlayground.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly Db db;

        public ProductsController(Db db)
        {
            this.db = db;

            if (db.Products.Count() == 0)
            {
                db.Products.Add(new Product { Id = 19201, Name = "Lego Nexo Knights King I", UnitPrice = 45 });
                db.Products.Add(new Product { Id = 23942, Name = "Lego Starwars Minifigure Jedi", UnitPrice = 55 });
                db.Products.Add(new Product { Id = 30021, Name = "Star Wars çay takımı ", UnitPrice = 35.50 });
                db.Products.Add(new Product { Id = 30492, Name = "Star Wars kahve takımı", UnitPrice = 24.40 });

                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return db.Products.ToList();
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = db.Products.FirstOrDefault(t => t.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return new ObjectResult(product);
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
            //TODO:Yazılacak
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            //TODO:Yazılacak
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //TODO:Yazılacak
        }
    }
}
