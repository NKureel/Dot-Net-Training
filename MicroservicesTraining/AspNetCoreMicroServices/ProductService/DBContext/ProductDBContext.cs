using Microsoft.EntityFrameworkCore;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.DBContext
{
    public class ProductDBContext:DbContext
    {        
        public ProductDBContext(DbContextOptions<ProductDBContext> options):base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<ProductTbl> productTbls { get; set; }
    }
}
