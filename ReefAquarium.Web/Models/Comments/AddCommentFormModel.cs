namespace ReefAquarium.Web.Models.Comments
{
    using System.ComponentModel.DataAnnotations;

    public class AddCommentFormModel
    {
        [Required]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public int AquariumId { get; set; }
    }
}
