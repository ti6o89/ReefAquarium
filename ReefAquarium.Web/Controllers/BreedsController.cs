namespace ReefAquarium.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using System.Threading.Tasks;

    public class BreedsController : Controller
    {
        private readonly IBreedService breeds;

        public BreedsController(IBreedService breeds)
        {
            this.breeds = breeds;
        }

        public async Task<IActionResult> All()
            => View(await this.breeds.AllAsync());

        public async Task<IActionResult> Details(int id)
            => View(await this.breeds.ById(id));
    }
}
