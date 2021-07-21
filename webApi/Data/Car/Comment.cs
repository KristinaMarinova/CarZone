using System;
namespace CarZone.Data
{
    public class Comment : BaseCar
    {
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    }
}
