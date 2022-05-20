using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        SampledbContext _sample;
        public SampleController(SampledbContext context)
        {
            _sample = context;
        }


        [HttpGet]
        public IEnumerable<TblSample> get()
        {
            return _sample.TblSamples.ToList();
        }
    }
}
