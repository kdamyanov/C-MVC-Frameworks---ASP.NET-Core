using System.Collections.Generic;
using SpinningFish.Services.Shop.Models.ShoppingCart;

namespace SpinningFish.Services.Shop
{
    public interface IShoppingCartManager
    {
        void AddToCart(string id, int productId);

        void RemoveFromCart(string id, int productId);

        IEnumerable<CartItem> GetItems(string id);

        void Clear(string id);
    }
}
