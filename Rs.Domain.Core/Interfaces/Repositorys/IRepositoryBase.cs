using System;
using System.Collections.Generic;

namespace ReceitaSearch.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();

        void DetachLocal(Func<TEntity, bool> predicate);
    }
}