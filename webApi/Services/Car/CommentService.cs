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

        public CommentDTO AddComment(int carId, string content, string username)
        {
            var commentToAdd = new Comment {
                UserId = user.UserId,
                CarId = carId,
                CreatedTime = DateTime.UtcNow,
                Content = content
            };

            context.Comments.Add(commentToAdd);
            context.SaveChanges();

            var userPicPath = context.Users.Where(x => x.UserName == username).Select(x => x.PicPath).FirstOrDefault();

            var commentToReturn = new CommentDTO {
                Id = commentToAdd.Id,
                UserId = user.UserId,
                Content = content,
                UserName = username,
                CreatedTime = DateTime.UtcNow,
                UserProfilePicUrl = userPicPath
            };

            return commentToReturn;
        }


        public IEnumerable<CommentDTO> DeleteComment(int carId, int commentId)
        {
            var commentToDelete = context.Comments
                .Where(x => x.CarId == carId && x.Id == commentId)
                .SingleOrDefault();

            if (commentToDelete != null)
            {
                context.Remove(commentToDelete);
                context.SaveChanges();
            }

            return this.GetAllComments(carId);
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
