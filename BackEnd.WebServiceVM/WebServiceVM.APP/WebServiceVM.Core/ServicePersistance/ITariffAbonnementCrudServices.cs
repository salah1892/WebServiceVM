using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceVM.Core.Entity;

namespace WebServiceVM.Core.ServicePersistance
{
    public interface ITariffAbonnementCrudServices
    {
        Task<TariffAbonnement> AddTariffAbonnement(string typeAbonnement, DateTime dateDebut,
            DateTime dateFin);

        Task<bool> DeleteTariffAbonnement(Guid id);
        Task<TariffAbonnement> SearchTariffAbonnementByID(Guid id);
        Task<ICollection<TariffAbonnement>> ListTariffAbonnement();
        Task<ICollection<TariffAbonnement>> SearchListTariffAbonnementById(Guid id);

        Task<TariffAbonnement> UpdateTariffAbonnement(Guid id, string typeAbonnement, DateTime dateDebut,
            DateTime dateFin);
    }
}
