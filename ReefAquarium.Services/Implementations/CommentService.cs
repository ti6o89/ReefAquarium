namespace ReefAquarium.Services.Implementations
{
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public class CommentService : ICommentService
    {
        private readonly ReefAquariumDbContext db;

        public CommentService(ReefAquariumDbContext db)
        {
            this.db = db;
        }

        public async Task AddAsync(string comment, string authorId, int aquariumId)
        {
            var result = new Comment
            {
                Content = comment,
                PublishDate = DateTime.UtcNow,
                AuthorId = authorId,
                AquariumId = aquariumId
            };

            this.db.Add(result);
            await this.db.SaveChangesAsync();
        }

        public async Task DeletetAsync(int id)
        {
            var existingComment = await this.db
                .Comments
                .FindAsync(id);

            if (existingComment == null)
            {
                return;
            }

            this.db.Remove(existingComment);

            await this.db.SaveChangesAsync();
        }

        public async Task<bool> UserIsAquthor(string userId, int commentId)
            => await this.db
                .Comments
                .AnyAsync(c => c.Id == commentId && c.AuthorId == userId);
    }
}
