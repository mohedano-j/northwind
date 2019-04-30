using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Services.Data;

namespace Northwind.Web.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet()]
        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> resultList;
            using (var ctx = new NorthwindDbContext())
            {
                resultList = ctx.Products.ToList();
            }
            return resultList;
        }

        [HttpGet("slowly")]
        public IEnumerable<Product> Slowly()
        {
            Thread.Sleep(5000);
            IEnumerable<Product> resultList;
            using (var ctx = new NorthwindDbContext())
            {
                resultList = ctx.Products.ToList();
            }
            return resultList;
        }

        [HttpGet("search/{term}")]
        public IEnumerable<Product> Search(string term)
        {
            IEnumerable<Product> resultList;
            using (var ctx = new NorthwindDbContext())
            {
                resultList = ctx.Products.Where(x => x.ProductName.Contains(term)).ToList();
            }
            return resultList;
        }

        [HttpGet("category/{categoryId}")]
        public IEnumerable<Product> GetByCategoryId(int categoryId)
        {
            IEnumerable<Product> resultList;
            using (var ctx = new NorthwindDbContext())
            {
                resultList = ctx.Products.Where(x => x.CategoryId == categoryId).ToList();
            }
            return resultList;
        }

        [HttpGet("{productId}")]
        public Product GetOne(int productId)
        {
            using (var ctx = new Northwind.Services.Data.NorthwindDbContext())
            {
                return ctx.Products.FirstOrDefault(x => x.ProductId == productId);
            }
        }

        [HttpPost()]
        public async Task<Product> Add([FromBody] Product value)
        {
            using (var ctx = new NorthwindDbContext())
            {
                ctx.Products.Add(value);
                await ctx.SaveChangesAsync();
            }
            return value;
        }

        [HttpPut()]
        public async Task<Product> Edit([FromBody] Product value)
        {
            Product productToUpdate = null;

            using (var ctx = new NorthwindDbContext())
            {
                productToUpdate = ctx.Products.FirstOrDefault(x => x.ProductId == value.ProductId);
                
                productToUpdate.ProductName = value.ProductName;
                productToUpdate.CategoryId = value.CategoryId;
                productToUpdate.UnitPrice = value.UnitPrice;
                productToUpdate.UnitsInStock = value.UnitsInStock;

                ctx.Products.Update(productToUpdate);

                await ctx.SaveChangesAsync();
            }
            return productToUpdate;
        }

        [HttpDelete("{productId}")]
        public async Task<Product> Delete(int productId)
        {
            Product productToDelete = null; 

            using (var ctx = new Northwind.Services.Data.NorthwindDbContext())
            {
                productToDelete = ctx.Products.FirstOrDefault(x => x.ProductId == productId);

                ctx.Products.Remove(productToDelete);
                await ctx.SaveChangesAsync();
            }
            return productToDelete;
        }
    }
}
