using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ECommerceContext context;
        public CategoryController(ECommerceContext eCommerce)
        {
            context = eCommerce;
        }

        [HttpGet]
        [Route("GetAllCategory")]
        public IEnumerable<TblCategory> GetAllCategory()
        {
            return context.TblCategories;
        }
    }
}
