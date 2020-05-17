using RS.Application.DTO.DTO;
using RS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Infra.CrossCutting.Adapter.Interfaces
{
    public interface IMapperAtividade
    {
        #region Mappers

        Atividade MapperToEntity(AtividadeDTO AtividadeDTO);

        IEnumerable<AtividadeDTO> MapperListAtividades(IEnumerable<Atividade> Atividades);

        AtividadeDTO MapperToDTO(Atividade Atividade);

        #endregion

    }
}
