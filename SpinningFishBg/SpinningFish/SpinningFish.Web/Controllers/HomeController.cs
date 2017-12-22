using System.Threading.Tasks;
using SpinningFish.Services.Shop;

namespace SpinningFish.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly IReelService reels;
        private readonly IBrandService brands;

        public HomeController(
            IReelService reels,
            IBrandService brands)
        {
            this.reels = reels;
            this.brands = brands;
        }

        public async Task<IActionResult> Index()
        {
            var allReels = await this.reels.AllReelsAsync();

            return View(allReels);
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
