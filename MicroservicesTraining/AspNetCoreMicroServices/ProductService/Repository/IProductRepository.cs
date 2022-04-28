using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Repository
{
    public interface IProductRepository
    {
        public IEnumerable<ProductTbl> GetAllProduct();
        public void InsertProduct(ProductTbl tbl);

        public void UpdateProduct(ProductTbl tbl);

        public void SaveProduct();
    }
}
