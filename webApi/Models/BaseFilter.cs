namespace CarZone.Models
{
    public abstract class BaseFilter
    {
        public virtual int Limit { get; set; } = 9;
        public virtual int Offset { get; set; } = 0;
    }
}
