using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Northwind.Web.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet("")]
        public IEnumerable<Category> GetAll()
        {
            IEnumerable<Category> resultList;
            using (var ctx = new Northwind.Services.Data.NorthwindDbContext())
            {
                resultList = ctx.Categories.ToList();
            }
            return resultList;
        }
    }
}
