using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lektion10.Model.Entities;
using Lektion10.Model.Abstract;

namespace Lektion10.Model.Repositories
{
    public class FakeProductRepository : IProductRepository 
    {
        private List<Product> products;
        public FakeProductRepository()
        {
            var catOutdoor = new Category { CategoryID = 1, Name = "Outdoor sports" };
            var catSkiing = new Category { CategoryID = 2, Name = "Ski sports" };
            var catHiking = new Category { CategoryID = 3, Name = "Hiking" };

            products = new List<Product>() {
                new Product { ProductID = 1, Name = "Football", Price = 25, Category = catOutdoor },
                new Product { ProductID = 2, Name = "Surf Board", Price = 179, Category = catOutdoor },
                new Product { ProductID = 3, Name = "Running Shoes", Price = 95, Category = catOutdoor },
                new Product { ProductID = 4, Name = "Goggles", Price = 25, Category = catSkiing },
                new Product { ProductID = 5, Name = "Snowboard", Price = 179, Category = catSkiing },
                new Product { ProductID = 6, Name = "Ski Boots", Price = 95, Category = catSkiing },
                new Product { ProductID = 7, Name = "Camp Stove", Price = 25, Category = catHiking },
                new Product { ProductID = 8, Name = "Tent", Price = 179, Category = catHiking },
                new Product { ProductID = 9, Name = "Hiking Boots", Price = 95, Category = catHiking },
            };
        }

        public IQueryable<Product> Products { get { return products.AsQueryable<Product>(); } }
        public void Delete(Product p) { products.Remove(p); }
        public void Save(Product p) 
        {
            if (p.ProductID == 0)
            {
                products.Add(p);
            }
            else
            {
                var existing = products.FirstOrDefault(prod => prod.ProductID == p.ProductID);
                if (null != existing)
                    products[products.IndexOf(existing)] = p;
                else
                    products.Add(p);
            }
        }

        public Product Get(int id)
        {
            return products.FirstOrDefault(p => p.ProductID == id);
        }
    }
}