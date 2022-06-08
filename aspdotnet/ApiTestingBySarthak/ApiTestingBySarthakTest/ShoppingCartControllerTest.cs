using ApiTestingBySarthak.Controllers;
using ApiTestingBySarthak.Models;
using ApiTestingBySarthak.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiTestingBySarthakTest
{
    public class ShoppingCartControllerTest
    {
        private readonly ShoppingItemsController _controller;
        private readonly IShoppingCartService _service;
        
        public ShoppingCartControllerTest()
        {
            _service = new ShoppingCartServiceFake();
            _controller = new ShoppingItemsController(_service);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            //Act
            var okResult = _controller.Get();
            //Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            //Act
            var okResult = _controller.Get() as OkObjectResult;
            //Assert
            var items = Assert.IsType<List<ShoppingItem>>(okResult.Value);
            Assert.Equal(3,items.Count);
        }
        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            //Act
            var notFoundResult = _controller.Get(Guid.NewGuid()) as OkObjectResult;
            //Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }
        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            //Act
            var testGuid = new Guid("2"); 
            var okResult = _controller.Get(testGuid);
            //Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
    }
}
