using DDDWebAPI.Infrastructure.Data;
using ReceitaSearch.Domain.Core.Interfaces.Repositorys;
using RS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Infra.Repository.Repositorys
{
    public class RepositoryQSA : RepositoryBase<QSA>, IRepositoryQSA
    {
        private readonly SqlContext _context;
        public RepositoryQSA(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
