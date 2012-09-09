using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Lektion10.Model.Abstract;
using Lektion10.Model.Entities;
using Lektion10.Model.Repositories;
using System.Configuration;
using Moq;

namespace Lektion10.Web.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            //ninjectKernel.Bind<IProductRepository>().ToConstant(new FakeProductRepository());

            /*
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product> {
                new Product { ProductID = 1, Name = "Football", Price = 25 },
                new Product { ProductID = 2, Name = "Surf Board", Price = 179 },
                new Product { ProductID = 3, Name = "Running Shoes", Price = 95 },
                new Product { ProductID = 4, Name = "Goggles", Price = 25 },
                new Product { ProductID = 5, Name = "Snowboard", Price = 179 },
                new Product { ProductID = 6, Name = "Ski Boots", Price = 95 },
                new Product { ProductID = 7, Name = "Camp Stove", Price = 25 },
                new Product { ProductID = 8, Name = "Tent", Price = 179 },
                new Product { ProductID = 9, Name = "Hiking Boots", Price = 95 },
            }.AsQueryable());
            mock.Setup(m => m.Get(It.IsAny<int>())).Returns(new Product { ProductID = 1, Name = "Football", Price = 25 });
            ninjectKernel.Bind<IProductRepository>().ToConstant(mock.Object);
             /**/

            ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
    }
}