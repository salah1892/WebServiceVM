using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceVM.Core.Entity;

namespace WebServiceVM.Core.ServicePersistance
{
    public interface IParametreCrudServices
    {
        public Task<Parametre> AddParametre(Guid id, int typePayement, string DescriptionPayement);

        public Task<bool> DeleteParametre(Guid id);
        public Task<ICollection<Parametre>> ListParametres();
        public Task<Parametre> SearchParametreByID(Guid id);
        public Task<Parametre> UpdateParametre(Guid id, int parametre, string DescriptionPayement);
    }
}
