namespace SpinningFish.Web.Areas.Admin.Controllers
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.Shop;
    using Services.Admin;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Web.Controllers;

    public class ReelsController : BaseAdminController
    {
        private readonly IAdminReelService reels;
        private readonly IAdminBrandService brands;

        public ReelsController(
            IAdminReelService reels, 
            IAdminBrandService brands)
        {
            this.reels = reels;
            this.brands = brands;
        }

        public async Task<IActionResult> Index()
        {
            var allReels = await this.reels.AllListindAsync();
            return this.View(allReels);
        }

        public ActionResult Create()
            => this.View(new ReelFormModel
            {
                АddedOnDate = DateTime.UtcNow,
                Brands = this.GetBrandsListItem()
            });
        
        [HttpPost]
        public async Task<IActionResult> Create(ReelFormModel reelModel)
        {
            if (!this.ModelState.IsValid)
            {
                reelModel.Brands = this.GetBrandsListItem();
                return this.View(reelModel);
            }

            var image = await reelModel.Image.ToByteArrayAsync();

            await this.reels.Create(
                reelModel.Model,
                reelModel.Description,
                reelModel.Details,
                reelModel.VideoId,
                reelModel.АddedOnDate,
                reelModel.Price,
                reelModel.Quantity,
                reelModel.Category,
                image,
                reelModel.BrandId);

            this.TempData.AddSuccessMessage($"Reel {reelModel.Model} created successfully.");

            return this.RedirectToAction(nameof(this.Index));
        }

        public IActionResult Edit(int id)
        {
            var reel = this.reels.ById(id);

            if (reel == null)
            {
                return this.NotFound();
            }

            return this.View(new ReelEditFormModel
            {
                Model = reel.Model,
                Description = reel.Description,
                Details = reel.Details,
                VideoId = reel.VideoId,
                АddedOnDate = reel.АddedOnDate,
                Price = reel.Price,
                Quantity = reel.Quantity,
                Category = reel.Category
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ReelEditFormModel reelModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(reelModel);
            }

            await this.reels.Edit(
                id,
                reelModel.Model,
                reelModel.Description,
                reelModel.Details,
                reelModel.VideoId ,
                reelModel.АddedOnDate ,
                reelModel.Price ,
                reelModel.Quantity ,
                reelModel.Category);

            return RedirectToAction(nameof(this.Index));
        }

        public IActionResult Delete(int id) => this.View(id);

        public async Task<IActionResult> Destroy(int id)
        {
            await this.reels.Delete(id);

            return this.RedirectToAction(nameof(this.Index));
        }

        private  IEnumerable<SelectListItem> GetBrandsListItem()
            => this.brands
                .All()
                .Select(b => new SelectListItem
                {
                    Text = b.Name,
                    Value = b.Id.ToString()
                });
    }
}
