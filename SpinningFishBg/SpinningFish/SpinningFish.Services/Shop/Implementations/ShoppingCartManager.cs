using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using SpinningFish.Services.Shop.Models.ShoppingCart;

namespace SpinningFish.Services.Shop.Implementations
{
    public class ShoppingCartManager : IShoppingCartManager
    {
        private readonly ConcurrentDictionary<string, ShoppingCart> carts;

        public ShoppingCartManager()
        {
            this.carts = new ConcurrentDictionary<string, ShoppingCart>();
        }

        public void AddToCart(string id, int productId)
        {
            var shoppingCart = this.GetShoppingCart(id);

            shoppingCart.AddToCart(productId);
        }

        public void RemoveFromCart(string id, int productId)
        {
            var shoppingCart = this.GetShoppingCart(id);

            shoppingCart.RemoveFromCart(productId);

        }

        public IEnumerable<CartItem> GetItems(string id)
        {
            var shoppingCart = this.GetShoppingCart(id);

            return new List<CartItem>(shoppingCart.Items);
        }

        public void Clear(string id) => this.GetShoppingCart(id).Clear();


        private ShoppingCart GetShoppingCart(string id)
            => this.carts.GetOrAdd(id, new ShoppingCart());
    }
}
