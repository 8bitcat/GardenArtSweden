using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GardenArt.Core.Repository.Interfaces;
using GardenArt.Infrastructure.Database;
using System.Data.Entity;

namespace GardenArt.Core.Repository
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        private Entities _entityContext;
        protected DbSet<T> dbSet;
        
        
        internal GenericRepository(Entities entitiesContext)
        {
            this._entityContext = entitiesContext;
            this.dbSet = entitiesContext.Set<T>();
        }
        IEnumerable<T> IRepository<T>.BaseFetchAll()
        {
            
            return (from x in dbSet select x).AsEnumerable<T>();
        }

        IEnumerable<T> IRepository<T>.BaseFindById(int id)
        {
            throw new NotImplementedException();
        }

        void IRepository<T>.BaseAdd(T entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<T>.BaseDelete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}