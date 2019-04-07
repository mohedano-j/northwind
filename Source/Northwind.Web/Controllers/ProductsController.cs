using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Northwind.Web.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet("")]
        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> resultList;
            using (var ctx = new Northwind.Services.Data.NorthwindDataContext())
            {
                resultList = ctx.Products.ToList();
            }
            return resultList;
        }

        [HttpGet("search/{value}")]
        public IEnumerable<Product> GetBySearch(string value)
        {
            IEnumerable<Product> resultList;
            using (var ctx = new Northwind.Services.Data.NorthwindDataContext())
            {
                resultList = ctx.Products.Where(x=>x.ProductName.Contains(value)).ToList();
            }
            return resultList;
        }

        [HttpGet("category/{categoryId}")]
        public IEnumerable<Product> GetByCategoryId(int categoryId)
        {
            IEnumerable<Product> resultList;
            using (var ctx = new Northwind.Services.Data.NorthwindDataContext())
            {
                resultList = ctx.Products.Where(x => x.CategoryId == categoryId).ToList();
            }
            return resultList;
        }

        [HttpGet("{productId}")]
        public Product GetByProductId(int productId)
        {
            using (var ctx = new Northwind.Services.Data.NorthwindDataContext())
            {
                return ctx.Products.FirstOrDefault(x => x.ProductId == productId);
            }
        }

        [HttpPost]
        public void Post([FromBody] Product value)
        {
            using (var ctx = new Northwind.Services.Data.NorthwindDataContext())
            {
                ctx.Products.Add(value);
                ctx.SaveChanges();
            }
        }

        [HttpPut]
        public void Put([FromBody] Product value)
        {
            using (var ctx = new Northwind.Services.Data.NorthwindDataContext())
            {
                var productToUpdate = ctx.Products.FirstOrDefault(x => x.ProductId == value.ProductId);

                productToUpdate = AutoMapper.Mapper.Map<Product, Product>(value);

                ctx.SaveChanges();
            }
        }

        [HttpDelete("{productId}")]
        public void Delete(int productId)
        {
            using (var ctx = new Northwind.Services.Data.NorthwindDataContext())
            {
                var productToDelete = ctx.Products.FirstOrDefault(x => x.ProductId == productId);

                ctx.Products.Remove(productToDelete);
                ctx.SaveChanges();
            }
        }
    }
}
