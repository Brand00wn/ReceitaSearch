using DDDWebAPI.Infrastructure.Data;
using ReceitaSearch.Domain.Core.Interfaces.Repositorys;
using RS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Infra.Repository.Repositorys
{
    public class RepositoryAtividade : RepositoryBase<Atividade>, IRepositoryAtividade
    {
        private readonly SqlContext _context;
        public RepositoryAtividade(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
