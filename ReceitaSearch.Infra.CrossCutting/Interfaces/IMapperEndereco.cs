using RS.Application.DTO.DTO;
using RS.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ReceitaSearch.Infra.CrossCutting
{
    public interface IMapperEndereco
    {
        #region Mappers

        Endereco MapperToEntity(EnderecoDTO EnderecoDTO);

        IEnumerable<EnderecoDTO> MapperListEnderecos(IEnumerable<Endereco> Enderecos);

        EnderecoDTO MapperToDTO(Endereco Endereco);

        #endregion

    }
}
