using RS.Application.DTO.DTO;
using RS.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ReceitaSearch.Infra.CrossCutting
{
    public interface IMapperEntidade
    {
        #region Mappers

        Entidade MapperToEntity(EntidadeDTO EntidadeDTO);

        IEnumerable<EntidadeDTO> MapperListEntidades(IEnumerable<Entidade> Entidades);

        EntidadeDTO MapperToDTO(Entidade Entidade);

        #endregion

    }
}
