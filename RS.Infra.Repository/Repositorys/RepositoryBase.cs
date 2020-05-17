using DDDWebAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ReceitaSearch.Domain.Core.Interfaces.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RS.Infra.Repository
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly SqlContext _context;

        public RepositoryBase(SqlContext Context)
        {
            _context = Context;
        }

        public virtual void Add(TEntity obj)
        {
            try
            {
                _context.Set<TEntity>().Add(obj);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual void Update(TEntity obj)
        {

            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public virtual void Remove(TEntity obj)
        {
            try
            {
                _context.Set<TEntity>().Remove(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }

        public virtual void DetachLocal(Func<TEntity,bool> predicate)
        {
            var local = _context.Set<TEntity>().Local.Where(predicate).FirstOrDefault();
            if(local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }
        }
    }
}
