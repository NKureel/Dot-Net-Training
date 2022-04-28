using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Models;
using ProductService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductRepository _context;
        public ProductController(IProductRepository repository)
        {
            _context = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
           var listOfProduct= _context.GetAllProduct();
            return new OkObjectResult(listOfProduct);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductTbl tbl)
        {
            if (tbl != null)
            {
                using (var scope = new TransactionScope())
                {
                    _context.InsertProduct(tbl);
                    scope.Complete();
                    return Created("api/Product/", tbl);
                }
            }
            return new NoContentResult();
        }

        [HttpPut]
        public IActionResult Put([FromBody] ProductTbl tbl)
        {
            if (tbl != null)
            {
                using (var scope = new TransactionScope())
                {
                    _context.UpdateProduct(tbl);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
    }
}
