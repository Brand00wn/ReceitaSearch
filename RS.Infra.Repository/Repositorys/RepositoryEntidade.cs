using DDDWebAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ReceitaSearch.Domain.Core.Interfaces.Repositorys;
using RS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RS.Infra.Repository.Repositorys
{
    public class RepositoryEntidade : RepositoryBase<Entidade>, IRepositoryEntidade
    {
        private readonly SqlContext _context;
        public RepositoryEntidade(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }

        public Entidade CheckIfAlreadyExists(Entidade entidade)
        {
            return _context.Entidade.Where(x => x.CNPJ == entidade.CNPJ).FirstOrDefault();
        }

        public override IEnumerable<Entidade> GetAll()
        {
            return _context.Entidade.Include(q => q.QSA)
                .Include(end => end.Endereco)
                .Include(ats => ats.AtividadeSecundaria).ThenInclude(ats => ats.Atividade)
                .Include(atp => atp.AtividadePrincipal).ThenInclude(ats => ats.Atividade)
                .Where(w => w.Ativo == true);
        }

        public override Entidade GetById(int id)
        {
            return _context.Entidade.Where(w => w.Id == id)
                .Include(q => q.QSA)
                .Include(end => end.Endereco)
                .Include(ats => ats.AtividadeSecundaria).ThenInclude(ats => ats.Atividade)
                .Include(atp => atp.AtividadePrincipal).ThenInclude(ats => ats.Atividade)
                .Where(w => w.Ativo == true).FirstOrDefault();
        }
    }
}
