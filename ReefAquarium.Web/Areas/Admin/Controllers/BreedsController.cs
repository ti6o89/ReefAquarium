namespace ReefAquarium.Web.Areas.Admin.Controllers
{
    using Areas.Admin.Models.Breeds;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Services.Admin;
    using System.Threading.Tasks;
    using Web.Controllers;

    [Area("Admin")]
    public class BreedsController : Controller
    {
        private readonly IAdminBreedService breeds;

        public BreedsController(IAdminBreedService breeds)
        {
            this.breeds = breeds;
        }

        public IActionResult Add()
            => View();

        [HttpPost]
        public async Task<IActionResult> Add(AddBreedFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.breeds.AddBreedAsync(
                model.Name,
                model.MinTankSize,
                model.ReefCompatible,
                model.CareLevel,
                model.Temperament,
                model.MaxSize,
                model.Diet,
                model.ImageUrl);

            TempData.AddSuccessMessage($"Breed {model.Name} was successfully created.");
            return RedirectToAction(nameof(AquariumsController.All), "Aquariums", new { area = string.Empty });
        }
    }
}
