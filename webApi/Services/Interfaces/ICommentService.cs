using System.Collections.Generic;
using CarZone.Data;
using CarZone.Models.DTOs;

namespace CarZone.Services
{
    public interface ICommentService
    {
        IEnumerable<CommentDTO> GetAllComments(int carId);
        int GetCountOfComments(int carId);
        Comment AddComment(int carId, string content);
        IEnumerable<CommentDTO> DeleteComment(int carId, int commentId);
        void UpdateComment(int carId, int commentId, Comment comment);
    }
}
