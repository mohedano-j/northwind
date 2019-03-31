using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Northwind.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: /products/
        [HttpGet(Name = nameof(GetAll))]
        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> productList;
            using (var ctx = new Northwind.Services.Data.NorthwindDataContext())
            {
                productList = ctx.Products.ToList();
            }
            return productList;
        }

        // GET: /products/search/{value}
        [HttpGet("search/{value}", Name = nameof(GetBySearch))]
        public IEnumerable<Product> GetBySearch(string value)
        {
            IEnumerable<Product> productList;
            using (var ctx = new Northwind.Services.Data.NorthwindDataContext())
            {
                productList = ctx.Products.Where(x=>x.ProductName.Contains(value)).ToList();
            }
            return productList;
        }

        // GET: /products/category/{categoryId}
        [HttpGet("category/{categoryId}", Name = nameof(GetByCategoryId))]
        public IEnumerable<Product> GetByCategoryId(int categoryId)
        {
            IEnumerable<Product> productList;
            using (var ctx = new Northwind.Services.Data.NorthwindDataContext())
            {
                productList = ctx.Products.Where(x => x.CategoryId == categoryId).ToList();
            }
            return productList;
        }


        // GET: /products/{productId}
        [HttpGet("{productId}", Name = nameof(GetByProductId))]
        public Product GetByProductId(int productId)
        {
            using (var ctx = new Northwind.Services.Data.NorthwindDataContext())
            {
                return ctx.Products.FirstOrDefault(x => x.ProductId == productId);
            }
        }

        // POST: /products/{product}
        [HttpPost]
        public void Post([FromBody] Product value) => throw new NotImplementedException();

        // PUT: /products/{product}
        [HttpPut]
        public void Put([FromBody] Product value) => throw new NotImplementedException();

        // DELETE: /products/{productId}
        [HttpDelete("{productId}")]
        public void Delete(int productId) => throw new NotImplementedException();       
    }
}
