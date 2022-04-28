using ProductService.DBContext;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDBContext _context;
        public ProductRepository(ProductDBContext productDB)
        {
            _context = productDB;
        }
        public IEnumerable<ProductTbl> GetAllProduct()
        {
            return _context.productTbls.ToList();
        }

        public void InsertProduct(ProductTbl tbl)
        {
            _context.productTbls.Add(tbl);
            SaveProduct();
        }

        public void SaveProduct()
        {
            _context.SaveChanges();
        }

        public void UpdateProduct(ProductTbl tbl)
        {
            _context.Entry(tbl).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            SaveProduct();
        }
    }
}
