using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using CarZone.Data;
using CarZone.Models.DTOs;
using CarZone.Services;

namespace CarZone.Controllers
{
    [Route("api/Cars/{carId:int}/comments")]
    [ApiController]
    public class CommentsControler : ControllerBase
    {
        private readonly ICommentService commentService;

        public CommentsControler(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet]
        public IEnumerable<CommentDTO> GetAllComments(int carId)
        {
            return commentService.GetAllComments(carId);
        }

        [HttpPost]
        public Comment PostComment(int carId, Comment comment)
        {
            return commentService.AddComment(carId, comment);
        }

        [HttpDelete("{id:int}")]
        public IEnumerable<CommentDTO> DeleteComment(int carId, int id)
        {
            return commentService.DeleteComment(carId, id);
        }

        [HttpPut("{commentId:int}")]
        public void UpdateComment(int carId, int commentId, Comment comment)
        {
            commentService.UpdateComment(carId, commentId, comment);
        }
    }
}
