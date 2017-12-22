using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SpinningFish.Data;
using SpinningFish.Services.Shop;
using SpinningFish.Web.Areas.Shop.Models;
using SpinningFish.Web.Infrastructure.Extensions;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SpinningFish.Data.Models;
using SpinningFish.Services.Shop.Models.ShoppingCart;
using SpinningFish.Web.Controllers;

namespace SpinningFish.Web.Areas.Shop.Controllers
{
    public class ShoppingCartController : BaseShopController
    {
        private readonly IShoppingCartManager shoppingCartManager;
        private readonly SpinningFishDbContext db;
        private readonly UserManager<User> userManager;

        public ShoppingCartController(
            IShoppingCartManager shoppingCartManager,
            SpinningFishDbContext db,
            UserManager<User> userManager)
        {
            this.shoppingCartManager = shoppingCartManager;
            this.db = db;
            this.userManager = userManager;
        }

        public  IActionResult Items()
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            var items = this.shoppingCartManager.GetItems(shoppingCartId);

            var itemsWithDetails = this.GetCartItem(items);

            return this.View(itemsWithDetails);
        }

        public IActionResult AddToCart(int id)
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            this.shoppingCartManager.AddToCart(shoppingCartId,id);

            return RedirectToAction(nameof(this.Items));
        }

        [Authorize]
        public IActionResult FinishOrder()
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            var items = this.shoppingCartManager.GetItems(shoppingCartId);
            
            var itemsWithDetails = this.GetCartItem(items);

            var order = new Order
            {
                UserId = this.userManager.GetUserId(User),
                TotalPrice = itemsWithDetails.Sum(i => i.Price * i.Quantity)
            };

            foreach (var item in itemsWithDetails)
            {
                order.Items.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    ProductPrice = item.Price,
                    Quantity = item.Quantity
                });
            }

            this.db.Add(order);
            this.db.SaveChanges();

            this.shoppingCartManager.Clear(shoppingCartId);

            return RedirectToAction(nameof(Success));
        }

        public IActionResult Success()
        {
            return this.View();
        }

        private List<CartItemViewModel> GetCartItem(IEnumerable<CartItem> items)
        {
            var itemIds = items.Select(i => i.ProductId);

            var itemWithDetails = this.db
                .Reels
                .Where(pr => itemIds.Contains(pr.Id))
                .Select(pr => new CartItemViewModel
                {
                    ProductId = pr.Id,
                    Title = pr.Model,
                    Price = pr.Price,
                    Quantity = pr.Quantity
                })
                .ToList();

            var itemQuantities = items.ToDictionary(i => i.ProductId, i => i.Quantity);


            itemWithDetails.ForEach(i => i.Quantity = itemQuantities[i.ProductId]);

            return itemWithDetails;
        }  
    }
}
