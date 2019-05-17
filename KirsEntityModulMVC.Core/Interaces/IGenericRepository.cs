using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KirsEntityModulMVC.Core.Interaces
{
    public interface IGenericRepository<TEntity,TId> where TEntity:class
    {
        List<TEntity> GetAll();
        TEntity Get(TId id);
        void Create(TEntity model);
        void Edit( TEntity model,TId id);
        void Delete(TId id);
    }
}
