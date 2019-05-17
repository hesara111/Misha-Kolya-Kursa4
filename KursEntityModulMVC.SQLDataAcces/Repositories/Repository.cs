using KirsEntityModulMVC.Core.Interaces;
using KursEntityModulMVC.SQLDataAcces.Entities;
using PhyApp.Core.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursEntityModulMVC.SQLDataAcces.Repositories
{
    public class Repository<TEntity,TId>:IGenericRepository<TEntity,TId> where TEntity: class
    {
        CoursesDbContext context;
        DbSet<TEntity> _dbSet;
        public Repository()
        {

        }

        public Repository(CoursesDbContext Context)
        {
            context = Context;
            _dbSet = context.Set<TEntity>();
        }

        //public List<Book> Sort(int id)
        //{
        //    return context.Books.Where(x=>x.AuthorId==id).ToList();
        //}

        public void Create(TEntity model)
        {
            _dbSet.Add(model);
            context.SaveChanges();
        }

        public void Delete(TId id)
        {
            var model = _dbSet.Find(id);
            _dbSet.Remove(model);
            context.SaveChanges();
        }

        public void Edit(TEntity model, TId id) 
        {
            var mode = _dbSet.Find(id);
            if(mode==null)
            {
                return;
            }
            context.Entry(mode).CurrentValues.SetValues(model);
            context.SaveChanges();
        }

        public void Edit(TEntity model)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(TId id)
        {
            return _dbSet.Find(id);
        }

        public List<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        
    }
}
