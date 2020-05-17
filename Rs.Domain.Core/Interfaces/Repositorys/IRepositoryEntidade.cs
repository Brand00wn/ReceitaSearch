using RS.Domain.Entities;

namespace ReceitaSearch.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryEntidade : IRepositoryBase<Entidade>
    {
        Entidade CheckIfAlreadyExists(Entidade entidade);
    }
}