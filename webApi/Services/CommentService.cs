using System.Collections.Generic;
using System.Linq;
using WebCarsProject.Data;
using WebCarsProject.Models.DTOs;

namespace WebCarsProject.Services
{
    public class CommentService : ICommentService
    {
        private readonly AppDbContext _context;
        private readonly UserContext _user;
        public CommentService(AppDbContext context, UserContext user)
        {
            _context = context;
            _user = user;
        }
        public IEnumerable<CommentDTO> GetAllComments(int carId)
        {
            var commentDTO = _context.Comments
              .Where(x => x.CarId == carId)
               .Select(e => new CommentDTO
               {
                   UserName = e.User.UserName,
                   UserId = e.User.Id,
                   UserProfilePicUrl = e.User.PicPath,
                   Content = e.Content,
                   CreatedTime = e.CreatedTime,
                   Id = e.Id

               }).OrderBy(x=>x.CreatedTime).ToList();

            return commentDTO;
        }
        public int GetCountOfComments(int carId)
        {
            return _context.Comments.Where(x => x.CarId == carId).Count();
        }
        public void AddComment(int carId, Comment comment)
        {
           
            comment.UserId = _user.UserId;
            comment.CarId = carId;
            _context.Comments.Add(comment);

            _context.SaveChanges();
        }

        public IEnumerable<CommentDTO> DeleteComment(int carId, int commentId)
        {
            var commentToDelete = _context.Comments
                .Where(x => x.CarId == carId && x.Id == commentId)
                .SingleOrDefault();

            _context.Remove(commentToDelete);
            _context.SaveChanges();

            var commentDTO = _context.Comments
              .Where(x => x.CarId == carId)
               .Select(e => new CommentDTO
               {
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
            var existingComment = _context.Comments
               .Where(x => x.Id == commentId && x.CarId == carId)
               .SingleOrDefault();

            if (existingComment != null)
            {
                existingComment.Content = comment.Content;
                _context.SaveChangesAsync();
            }
        }
    }
}
