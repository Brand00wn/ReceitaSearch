using ReceitaSearch.Domain.Core.Interfaces.Services;
using ReceitaSearch.Domain.Core.Interfaces.Repositorys;
using RS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Domain.Services.Services
{
    public class ServiceEntidade : ServiceBase<Entidade>, IServiceEntidade
    {
        public readonly IRepositoryEntidade _repositoryEntidade;

        public ServiceEntidade(IRepositoryEntidade RepositoryEntidade)
            : base(RepositoryEntidade)
        {
            _repositoryEntidade = RepositoryEntidade;
        }

        public Entidade CheckIfAlreadyExists(Entidade entidade)
        {
            return _repositoryEntidade.CheckIfAlreadyExists(entidade);
        }

        public override IEnumerable<Entidade> GetAll()
        {
            return _repositoryEntidade.GetAll();
        }

        public override Entidade GetById(int id)
        {
            return _repositoryEntidade.GetById(id);
        }

        public override void Update(Entidade obj)
        {
            this._repositoryEntidade.DetachLocal(_ => _.Id == obj.Id);
            _repositoryEntidade.Update(obj);
        }
    }
}
