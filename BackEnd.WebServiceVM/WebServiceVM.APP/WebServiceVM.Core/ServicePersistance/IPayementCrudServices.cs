using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceVM.Core.Entity;

namespace WebServiceVM.Core.ServicePersistance
{
    public interface IPayementCrudServices
    {
        Task<Payement> AddPayement(DateTime datePayement);
        Task<bool> DeletePayement(Guid id);
        Task<Payement> SearchPayementById(Guid id);
        Task<ICollection<Payement>> ListPayement();
        Task<ICollection<Payement>> SearchListPayementById(Guid id);
        Task<Payement> UpdatePayement(Guid id, DateTime datePayement);
    }
}
