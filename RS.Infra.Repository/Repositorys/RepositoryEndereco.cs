using DDDWebAPI.Infrastructure.Data;
using ReceitaSearch.Domain.Core.Interfaces.Repositorys;
using RS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Infra.Repository.Repositorys
{
    public class RepositoryEndereco : RepositoryBase<Endereco>, IRepositoryEndereco
    {
        private readonly SqlContext _context;
        public RepositoryEndereco(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
