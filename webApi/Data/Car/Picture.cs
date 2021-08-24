using System;

namespace CarZone.Data
{
    public class Picture
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public string Paths { get; set; }
        public DateTime UploadTime { get; set; } = DateTime.UtcNow;
    }
}
