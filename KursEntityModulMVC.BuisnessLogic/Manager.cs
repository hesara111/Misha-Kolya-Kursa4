using KirsEntityModulMVC.Core.Interaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursEntityModulMVC.BuisnessLogic
{
    public class Manager<TEntity,TId> : IManager<TEntity,TId> where TEntity : class
    {
        private readonly IGenericRepository<TEntity, TId> _repo;
        public Manager()
        {

        }
        public Manager(IGenericRepository<TEntity,TId> repo)
        {
            _repo = repo;
        }


        public void Create(TEntity model)
        {
            _repo.Create(model);
        }

        public void Delete(TId id)
        {
            _repo.Delete(id);
        }

        public void Edit(TEntity model,TId id)
        {
            _repo.Edit(model,id);
        }

        public TEntity Get(TId id)
        {
            return _repo.Get(id);
        }

        public List<TEntity> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
