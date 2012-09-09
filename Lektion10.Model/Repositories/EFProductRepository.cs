using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lektion10.Model.Context;
using Lektion10.Model.Entities;
using Lektion10.Model.Abstract;

namespace Lektion10.Model.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Product> Products { get { return context.Products; } }

        public void Save(Product product)
        {
            if (product.ProductID == 0)
                context.Products.Add(product);
            else
            {
                context.Entry(product).State = System.Data.EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public Product Get(int id)
        {
            return context.Products.Include("Category").FirstOrDefault(p => p.ProductID == id);
        }
    }
}
