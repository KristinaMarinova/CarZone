using System;
namespace CarZone.Data
{
    public class Log
    {
		public int Id { get; set; }
        public string IP { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
		public string Protocol { get; set; }
		public string Host { get; set; }
		public string StatusCode { get; set; }
        public DateTime DateTime { get; set; }
    }
}