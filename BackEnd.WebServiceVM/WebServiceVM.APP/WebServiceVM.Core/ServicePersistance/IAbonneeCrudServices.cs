using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceVM.Core.Entity;

namespace WebServiceVM.Core.ServicePersistance
{
    public interface IAbonneeCrudServices
    {
        /// <summary>
        /// Methode asynchrone permet d'ajouter une Abonnee dans la Base 
        /// </summary>
        /// <param name="numCarte"></param>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <returns>Retourne Void</returns>
        Task<Abonnee> AddAbonnee(int numCarte, string nom, string prenom);

        Task<bool> DeleteAbonnee(Guid id);
        Task<ICollection<Abonnee>> ListAbonnee();
        Task<Abonnee> SearchAbonneeByID(Guid id);
        Task<ICollection<Abonnee>> SearchAbonneeByName(string name);
        Task<Abonnee> UpdateAbonnee(Guid id, int numCart, string name, string prenom);
    }
}
