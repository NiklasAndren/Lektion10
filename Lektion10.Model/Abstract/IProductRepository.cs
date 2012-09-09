using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lektion10.Model.Entities;

namespace Lektion10.Model.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        void Save(Product product);
        void Delete(Product product);
        Product Get(int id);
    }
}
