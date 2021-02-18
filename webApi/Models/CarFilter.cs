using WebCarsProject.Data;

namespace WebCarsProject.Models
{
    public class CarFilter : BaseFilter
    {
        public int? BrandId{ get; set; }
        public int? FuelId { get; set; }
        public int? TransmissionId { get; set; }
        public int? ColorId { get; set; }
        public string Model { get; set; }

    }
}
