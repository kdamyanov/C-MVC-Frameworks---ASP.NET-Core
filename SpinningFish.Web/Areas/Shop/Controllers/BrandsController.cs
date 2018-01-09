namespace SpinningFish.Web.Areas.Shop.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Shop;
    using System.Threading.Tasks;

    public class BrandsController : BaseShopController
    {
        private readonly IBrandService brands;

        public BrandsController(IBrandService brands)
        {
            this.brands = brands;
        }

        public async Task<IActionResult>  Index()
        {
            var allBrands = await this.brands.AllListingAsync();
            return this.View(allBrands);
        }

        


    }
}
