using ReceitaSearch.Domain.Core.Interfaces.Services;
using ReceitaSearch.Domain.Core.Interfaces.Repositorys;
using RS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Domain.Services.Services
{
    public class ServiceQSA : ServiceBase<QSA>, IServiceQSA
    {
        public readonly IRepositoryQSA _repositoryQSA;

        public ServiceQSA(IRepositoryQSA RepositoryQSA)
            : base(RepositoryQSA)
        {
            _repositoryQSA = RepositoryQSA;
        }

    }
}
