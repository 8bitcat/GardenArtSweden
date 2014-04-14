using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenArt.Core.Repository.Interfaces
{
    interface IRepository<T> where T : class
    {

        IEnumerable<T> BaseFetchAll();
        IEnumerable<T> BaseFindById(int id);
        void BaseAdd(T entity);
        void BaseDelete(T entity);
        




    }
}
