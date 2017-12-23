namespace ReefAquarium.Web.Areas.Admin.Controllers
{
    using Areas.Admin.Models.Breeds;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ReefAquarium.Data.Models;
    using Services.Admin;
    using System.Threading.Tasks;
    using Web.Controllers;

    [Area("Admin")]
    public class BreedsController : Controller
    {
        private readonly IAdminBreedService breeds;
        private readonly UserManager<User> userManager;

        public BreedsController(
            IAdminBreedService breeds,
            UserManager<User> userManager)
        {
            this.breeds = breeds;
            this.userManager = userManager;
        }

        public IActionResult Add()
            => View();

        [HttpPost]
        public async Task<IActionResult> Add(BreedFormModel model)
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

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var breed = await this.breeds.ById(id);

            if (breed == null)
            {
                return NotFound();
            }

            var user = await this.userManager.GetUserAsync(User);

            if (!await userManager.IsInRoleAsync(user, "Admin"))
            {
                return BadRequest();
            }

            return View(new BreedFormModel
            {
                Name = breed.Name,
                MinTankSize = breed.MinTankSize,
                ReefCompatible = breed.ReefCompatible,
                CareLevel = breed.CareLevel,
                Temperament = breed.Temperament,
                MaxSize = breed.MaxSize,
                Diet = breed.Diet,
                ImageUrl = breed.ImageUrl
            });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, BreedFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            await this.breeds.EditAsync(
                id,
                model.Name,
                model.MinTankSize,
                model.ReefCompatible,
                model.CareLevel,
                model.Temperament,
                model.MaxSize,
                model.Diet,
                model.ImageUrl);

            return RedirectToAction("All", "Breeds", new { area = string.Empty });
        }
    }
}
