namespace ReefAquarium.Web.Controllers
{
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Models.Fish;
    using Services;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class FishController : Controller
    {
        private readonly IFishService fish;
        private readonly ReefAquariumDbContext db;

        public FishController(
            IFishService fish,
            ReefAquariumDbContext db)
        {
            this.fish = fish;
            this.db = db;
        }

        public async Task<IActionResult> Add(int id)
            => View(new AddFishFormModel
            {
                Breeds = await this.GetBreeds(),
                AquariumId = id
            });

        [HttpPost]
        public async Task<IActionResult> Add(AddFishFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Breeds = await this.GetBreeds();
                return View(model);
            }

            await this.fish.AddAsync(
                model.Quantity,
                model.BreedId,
                model.AquariumId);

            var id = model.AquariumId;

            return RedirectToAction(nameof(AquariumsController.Details), "Aquariums", new { id });
        }

        [HttpPost]
        public async Task<IActionResult> PlusOne(int fishId, int id)
        {
            await this.fish.PlusOne(fishId);

            return RedirectToAction(nameof(AquariumsController.Details), "Aquariums", new { id });
        }

        [HttpPost]
        public async Task<IActionResult> SubstractOne(int fishId, int id)
        {
            await this.fish.SubstractOne(fishId);

            return RedirectToAction(nameof(AquariumsController.Details), "Aquariums", new { id });
        }

        private async Task<IEnumerable<SelectListItem>> GetBreeds()
        {
            var breeds = await this.db.Breeds
                .Select(b => new SelectListItem
                {
                    Text = b.Name,
                    Value = b.Id.ToString()
                })
                .ToListAsync();

            return breeds;
        }
    }
}
