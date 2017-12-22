using SpinningFish.Services.Admin;
using SpinningFish.Web.Areas.Admin.Models.Shop;
using SpinningFish.Web.Infrastructure.Extensions;
using System.Threading.Tasks;

namespace SpinningFish.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class BrandsController : BaseAdminController
    {
        private readonly IAdminBrandService brands;

        public BrandsController(IAdminBrandService brands)
        {
            this.brands = brands;
        }

        public async Task<IActionResult>  Index()
        {
            var allBrands = await this.brands.AllListindAsync(); 
            return this.View(allBrands);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BrandFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var image = await model.Image.ToByteArrayAsync();

            await this.brands.Create(model.Name,model.Description, image);
            
            TempData.AddSuccessMessage($"Brand {model.Name} created successfully.");

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
