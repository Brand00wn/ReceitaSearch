using ReceitaSearch.Domain.Core.Interfaces.Repositorys;
using RS.Domain.Entities;

namespace ReceitaSearch.Domain.Core.Interfaces.Services
{
    public interface IServiceEntidade : IServiceBase<Entidade>
    {
        Entidade CheckIfAlreadyExists(Entidade entidade);
    }
}