using WebServiceVM.Core.Entity;

namespace WebServiceVM.WebAPI.Controllers.ParkingController
{
    public class UpdateParkingRequest
    {
        public string NomParking { get; set; }
        public string TypeParking { get; set; }
        public string AdressParking { get; set; }
        public  ICollection<TariffAbonnement>? ListTariffAbonnement { get; set; }
    }
}
