using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceVM.Core.Entity;

namespace WebServiceVM.Core.ServicePersistance
{
    public interface IAbonnementCrudServices
    {
        Task<Abonnement> AddAbonnement(DateTime dateCreation, DateTime dateActivation,
            DateTime dateDesactivation);

        Task<bool> DeleteAbonnement(Guid id);

        Task<Abonnement> UpdateAbonnement(Guid id, DateTime dateCreation, DateTime dateActivation,
            DateTime dateDesactivation);

        Task<ICollection<Abonnement>> ListAbonnement();
        Task<Abonnement> SearchAbonnementByID(Guid id);
        Task<ICollection<Abonnement>> SearchListAbonnementByID(Guid id);
    }
}
