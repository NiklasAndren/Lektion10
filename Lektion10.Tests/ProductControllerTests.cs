using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lektion10.Model.Entities;
using Moq;
using Lektion10.Model.Abstract;
using Lektion10.Web.Controllers;

namespace Lektion10.Tests
{
    [TestClass]
    public class ProductControllerTests
    {
        [TestMethod]
        public void ProductController_Edit_CanSaveValidProduct()
        {
            //Arrange
            Product p = new Product { ProductID = 1, Name = "Test" };
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            var target = new ProductController(mock.Object);

            //Act
            var result = target.Edit(p);

            //Assert
            mock.Verify(r => r.Save(p), Times.Once());
        }

        [TestMethod]
        public void ProductController_Edit_CannotSaveInvalidProduct()
        {
            //Arrange
            Product p = new Product { ProductID = 1, Name = "Test" };
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            var target = new ProductController(mock.Object);
            target.ModelState.AddModelError("error", "error");

            //Act
            var result = target.Edit(p);

            //Assert
            mock.Verify(r => r.Save(It.IsAny<Product>()), Times.Never());
        }
    }
}
