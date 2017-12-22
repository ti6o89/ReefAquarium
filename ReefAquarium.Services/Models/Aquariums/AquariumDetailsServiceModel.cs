namespace ReefAquarium.Services.Models.Aquariums
{
    using Services.Models.Comments;
    using Services.Models.Fish;
    using System.Collections.Generic;

    public class AquariumDetailsServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        //in cm
        public int Length { get; set; }

        //in cm
        public int Width { get; set; }

        //in cm
        public int Height { get; set; }

        public int Volume => (this.Width * this.Height * this.Length) / 1000;

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public List<CommentServiceModel> Comments { get; set; } = new List<CommentServiceModel>();

        public string Owner { get; set; }

        public IEnumerable<FishServiceModel> Fish { get; set; }

        public bool UserIsOwner { get; set; }
    }
}
