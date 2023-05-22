using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceVM.Core.Entity;

namespace WebServiceVM.Core.ServicePersistance
{
    public interface IParkingCrudServices
    {
        Task<Parking> AddParking(string nomParking, string typeParking, string adressParking);
        Task<ICollection<Parking>> ListParking();
        Task<Parking> SearchParkingByID(Guid id);
        Task<bool> DeleteParking(Guid id);
        Task<Parking> UpdateParking(Guid id, string nomParking, string typeParking, string adressParking);
        Task<ICollection<Parking>> SearchParkingByName(string stname);
    }
}
