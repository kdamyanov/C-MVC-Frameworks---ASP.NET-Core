namespace SpinningFish.Services.Shop
{
    using Models.ShoppingCart;
    using System.Collections.Generic;

    public interface IShoppingCartManager
    {
        void AddToCart(string id, int productId);

        void RemoveFromCart(string id, int productId);

        IEnumerable<CartItem> GetItems(string id);

        void Clear(string id);
    }
}
