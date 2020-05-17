using ReceitaSearch.Domain.Core.Interfaces.Services;
using ReceitaSearch.Domain.Core.Interfaces.Repositorys;
using RS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Domain.Services.Services
{
    public class ServiceAtividade : ServiceBase<Atividade>, IServiceAtividade
    {
        public readonly IRepositoryAtividade _repositoryAtividade;

        public ServiceAtividade(IRepositoryAtividade RepositoryAtividade)
            : base(RepositoryAtividade)
        {
            _repositoryAtividade = RepositoryAtividade;
        }

    }
}
