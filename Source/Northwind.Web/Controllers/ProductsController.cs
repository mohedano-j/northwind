using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Northwind.Web.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper)
        {
            _mapper = mapper;
        }

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
        public async Task<Product> Post([FromBody] Product value)
        {
            using (var ctx = new Northwind.Services.Data.NorthwindDataContext())
            {
                ctx.Products.Add(value);
                await ctx.SaveChangesAsync();
            }
            return value;
        }

        [HttpPut]
        public async Task<Product> Put([FromBody] Product value)
        {
            Product productToUpdate = null;

            using (var ctx = new Northwind.Services.Data.NorthwindDataContext())
            {
                productToUpdate = ctx.Products.FirstOrDefault(x => x.ProductId == value.ProductId);
                
                productToUpdate.ProductName = value.ProductName;
                productToUpdate.CategoryId = value.CategoryId;

                ctx.Products.Update(productToUpdate);

                await ctx.SaveChangesAsync();
            }
            return productToUpdate;
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
