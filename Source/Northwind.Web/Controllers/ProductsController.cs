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
        [HttpGet("{sleep?}")]
        public IEnumerable<Product> GetAll(int sleep = 0)
        {
            Thread.Sleep(sleep);

            IEnumerable<Product> resultList;
            using (var ctx = new NorthwindDbContext())
            {
                resultList = ctx.Products.ToList();
            }
            return resultList;
        }

        [HttpGet("search/{term}/{sleep?}")]
        public IEnumerable<Product> Search(string term, int sleep = 0)
        {
            Thread.Sleep(sleep);

            IEnumerable<Product> resultList;
            using (var ctx = new NorthwindDbContext())
            {
                resultList = ctx.Products.Where(x => x.ProductName.Contains(term)).ToList();
            }
            return resultList;
        }

        [HttpGet("category/{categoryId}/{sleep?}")]
        public IEnumerable<Product> GetByCategoryId(int categoryId, int sleep = 0)
        {
            Thread.Sleep(sleep);

            IEnumerable<Product> resultList;
            using (var ctx = new NorthwindDbContext())
            {
                resultList = ctx.Products.Where(x => x.CategoryId == categoryId).ToList();
            }
            return resultList;
        }

        [HttpGet("{productId}/{sleep?}")]
        public Product GetOne(int productId, int sleep = 0)
        {
            Thread.Sleep(sleep);

            using (var ctx = new Northwind.Services.Data.NorthwindDbContext())
            {
                return ctx.Products.FirstOrDefault(x => x.ProductId == productId);
            }
        }

        [HttpPost("{sleep?}")]
        public async Task<Product> Add([FromBody] Product value, int sleep = 0)
        {
            Thread.Sleep(sleep);

            using (var ctx = new NorthwindDbContext())
            {
                ctx.Products.Add(value);
                await ctx.SaveChangesAsync();
            }
            return value;
        }

        [HttpPut("{sleep?}")]
        public async Task<Product> Edit([FromBody] Product value, int sleep = 0)
        {
            Thread.Sleep(sleep);

            Product productToUpdate = null;

            using (var ctx = new NorthwindDbContext())
            {
                productToUpdate = ctx.Products.FirstOrDefault(x => x.ProductId == value.ProductId);
                
                productToUpdate.ProductName = value.ProductName;
                productToUpdate.CategoryId = value.CategoryId;

                ctx.Products.Update(productToUpdate);

                await ctx.SaveChangesAsync();
            }
            return productToUpdate;
        }

        [HttpDelete("{productId}/{sleep?}")]
        public async Task<Product> Delete(int productId, int sleep = 0)
        {
            Thread.Sleep(sleep);
            Product productToDelete = null;
            using (var ctx = new Northwind.Services.Data.NorthwindDbContext())
            {
                productToDelete = ctx.Products.FirstOrDefault(x => x.ProductId == productId);

                ctx.Products.Remove(productToDelete ?? throw new InvalidOperationException());
                ctx.SaveChanges();
            }
            return productToDelete;

        }
    }
}
