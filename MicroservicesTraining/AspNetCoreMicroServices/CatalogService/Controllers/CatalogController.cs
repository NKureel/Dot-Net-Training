using CatalogService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        ICatalogRepository _catalogService;
        public CatalogController(ICatalogRepository catalogService)
        {
            _catalogService = catalogService;
        }
        [HttpGet("findall")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(_catalogService.FindAll());
            }
            catch
            {
                return BadRequest();
            }

        }

    }
}
