using ReceitaSearch.Domain.Core.Interfaces.Services;
using ReceitaSearch.Domain.Core.Interfaces.Repositorys;
using RS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Domain.Services.Services
{
    public class ServiceEndereco : ServiceBase<Endereco>, IServiceEndereco
    {
        public readonly IRepositoryEndereco _repositoryEndereco;

        public ServiceEndereco(IRepositoryEndereco RepositoryEndereco)
            : base(RepositoryEndereco)
        {
            _repositoryEndereco = RepositoryEndereco;
        }

    }
}
