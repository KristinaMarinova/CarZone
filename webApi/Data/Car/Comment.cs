using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
namespace WebCarsProject.Data
{
    public class Comment : BaseContentOfCar
    {
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    }
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
