using Xunit;
using ApiTestingBySarthak.Models;
using System.Collections.Generic;
using System;
using ApiTestingBySarthak.Services;
using System.Linq;

namespace ApiTestingBySarthakTest
{
    public class ShoppingCartServiceFake : IShoppingCartService
    {
        private readonly List<ShoppingItem> _shoppingCart;
        public ShoppingCartServiceFake()
        {
            _shoppingCart = new List<ShoppingItem>();
            {
                new ShoppingItem() { Id = new Guid("1"), Name = "Jon", Price = 100, Manufacturer = "Orange & Co." };
                new ShoppingItem() { Id = new Guid("2"), Name = "James", Price = 110, Manufacturer = "Orange Pvt. Ltd." };
            }
        }
        public ShoppingItem Add(ShoppingItem newitem)
        {
            newitem.Id = Guid.NewGuid();
            _shoppingCart.Add(newitem);
            return newitem;
        }
        public ShoppingItem GetById(Guid id)
        {
            return _shoppingCart.Where(i => i.Id == id).FirstOrDefault();
        }
        public IEnumerable<ShoppingItem> GetAllItems()
        {
            return _shoppingCart;
        }

        public void Remove(Guid id)
        {
            var existing = _shoppingCart.First(a => a.Id == id);
            _shoppingCart.Remove(existing);
        }
    }
}