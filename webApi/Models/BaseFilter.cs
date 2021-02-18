namespace WebCarsProject.Models
{
    public abstract class BaseFilter
    {
        public virtual int Limit { get; set; } = 10;
        public virtual int Offset { get; set; } = 0;
    }
}
