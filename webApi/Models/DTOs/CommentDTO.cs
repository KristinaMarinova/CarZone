using System;

namespace WebCarsProject.Models.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string UserProfilePicUrl { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
