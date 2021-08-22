using System;
using System.Collections.Generic;
using System.Linq;
using CarZone.Data;
using CarZone.Models.DTOs;

namespace CarZone.Services
{
    public class CommentService : ICommentService
    {
        private readonly AppDbContext context;
        private readonly UserContext user;
        public CommentService(AppDbContext context, UserContext user)
        {
            this.context = context;
            this.user = user;
        }
        public IEnumerable<CommentDTO> GetAllComments(int carId)
        {
            var commentDTO = context.Comments
              .Where(x => x.CarId == carId)
               .Select(e => new CommentDTO {
                   UserName = e.User.UserName,
                   UserId = e.User.Id,
                   UserProfilePicUrl = e.User.PicPath,
                   Content = e.Content,
                   CreatedTime = e.CreatedTime,
                   Id = e.Id

               }).OrderBy(x => x.CreatedTime).ToList();

            return commentDTO;
        }
        public int GetCountOfComments(int carId)
        {
            return context.Comments.Where(x => x.CarId == carId).Count();
        }

        public Comment AddComment(int carId, string content)
        {
            var commentToAdd = new Comment {
                UserId = user.UserId,
                CarId = carId,
                CreatedTime = DateTime.UtcNow,
                Content = content
            };

            context.Comments.Add(commentToAdd);
            context.SaveChanges();
            return commentToAdd;
        }



        public IEnumerable<CommentDTO> DeleteComment(int carId, int commentId)
        {
            var commentToDelete = context.Comments
                .Where(x => x.CarId == carId && x.Id == commentId)
                .SingleOrDefault();

            context.Remove(commentToDelete);
            context.SaveChanges();

            var commentDTO = context.Comments
              .Where(x => x.CarId == carId)
               .Select(e => new CommentDTO {
                   Id = e.Id,
                   UserName = e.User.UserName,
                   UserId = e.User.Id,
                   UserProfilePicUrl = e.User.PicPath,
                   Content = e.Content,
                   CreatedTime = e.CreatedTime

               }).ToList();

            return commentDTO;
        }

        public void UpdateComment(int carId, int commentId, Comment comment)
        {
            var existingComment = context.Comments
               .Where(x => x.Id == commentId && x.CarId == carId)
               .SingleOrDefault();

            if (existingComment != null)
            {
                existingComment.Content = comment.Content;
                context.SaveChangesAsync();
            }
        }
    }
}
