using CatalogService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Repository
{
    public interface ICatalogRepository
    {
        List<Category> FindAll();
    }
}
