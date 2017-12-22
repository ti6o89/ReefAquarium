namespace ReefAquarium.Web.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using System.Threading.Tasks;

    public class CommentsController : Controller
    {
        private readonly ICommentService comments;
        private readonly UserManager<User> userManager;

        public CommentsController(
            ICommentService comments,
            UserManager<User> userManager)
        {
            this.comments = comments;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Add()
            => View();

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(int id, string comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = this.userManager.GetUserId(User);

            await this.comments.AddAsync(comment, userId, id);

            return RedirectToAction(nameof(AquariumsController.Details), "Aquariums", new { id });
        }

        public async Task<IActionResult> Delete(int commentId, int id, string comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = this.userManager.GetUserId(User);

            await this.comments.DeletetAsync(commentId);

            return RedirectToAction(nameof(AquariumsController.Details), "Aquariums", new { id });
        }
    }
}
