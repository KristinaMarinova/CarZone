using System;
namespace CarZone.Data
{
    public class RequestSaver
    {
        public int Id { get; set; }
        public string Verb { get; set; }
        public string Path { get; set; }
        public string Protocol { get; set; }
        public DateTime Time { get; set; }
    }
}