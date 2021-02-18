using System.Collections.Generic;
using WebCarsProject.Data;
using WebCarsProject.Models.DTOs;

namespace WebCarsProject.Services
{
    public interface ICommentService
    {
        IEnumerable<CommentDTO> GetAllComments(int carId);
        int GetCountOfComments(int carId);
        void AddComment(int carId, Comment comment);
        IEnumerable<CommentDTO> DeleteComment(int carId, int commentId);
        void UpdateComment(int carId, int commentId, Comment comment);
    }
}
