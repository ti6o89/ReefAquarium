namespace ReefAquarium.Web.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Aquariums;
    using Services;
    using System.Threading.Tasks;

    public class AquariumsController : Controller
    {
        private readonly IAquariumService aquariums;
        private readonly UserManager<User> userManager;
        private readonly ICommentService comments;

        public AquariumsController(
            IAquariumService aquariums,
            UserManager<User> userManager,
            ICommentService comments)
        {
            this.aquariums = aquariums;
            this.userManager = userManager;
            this.comments = comments;
        }

        [Authorize]
        public IActionResult Create()
            => View();

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(AquariumFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.aquariums.CerateAsync(
                model.Title,
                model.Length,
                model.Width,
                model.Height,
                model.Description,
                model.ImageUrl,
                this.userManager.GetUserId(User));

            return RedirectToAction(nameof(AquariumsController.All), "Aquariums", new { area = string.Empty });
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var aquarium = await this.aquariums.ById(id);
            var userId = this.userManager.GetUserId(User);

            if (aquarium == null)
            {
                return NotFound();
            }

            if (!await this.aquariums.UserIsOwner(id, userId))
            {
                return BadRequest();
            }

            return View(new AquariumFormModel
            {
                Title = aquarium.Title,
                Length = aquarium.Length,
                Width = aquarium.Width,
                Height = aquarium.Height,
                Description = aquarium.Description,
                ImageUrl = aquarium.ImageUrl
            });          
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, AquariumFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.aquariums.EditAsync(
                id,
                model.Title,
                model.Length,
                model.Width,
                model.Height,
                model.Description,
                model.ImageUrl);

            return RedirectToAction(nameof(AquariumsController.Details), "Aquariums", new { id });
        }

        public async Task<IActionResult> All()
            => View(await this.aquariums.AllAsync());

        public async Task<IActionResult> Details(int id)
        {
            var model = await this.aquariums.ById(id);

            if (model == null)
            {
                return NotFound();
            }

            if (User.Identity.IsAuthenticated)
            {
                var userId = userManager.GetUserId(User);

                model.UserIsOwner = await this.aquariums.UserIsOwner(id, userId);
            }

            return View(model);
        }
    }
}
