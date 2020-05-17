using ReceitaSearch.Infra.CrossCutting;
using RS.Application.DTO.DTO;
using RS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Infra.CrossCutting.Adapter.Map
{
    public class MapperEndereco : IMapperEndereco
    {

        #region properties

        List<EnderecoDTO> EnderecoDTOs = new List<EnderecoDTO>();

        #endregion


        #region methods

        public Endereco MapperToEntity(EnderecoDTO EnderecoDTO)
        {
            Endereco Endereco = new Endereco
            {
                Bairro = EnderecoDTO.Bairro,
                CEP = EnderecoDTO.CEP,
                Complemento = EnderecoDTO.Complemento,
                Id = EnderecoDTO.Id,
                Logradouro = EnderecoDTO.Logradouro,
                Municipio = EnderecoDTO.Municipio,
                Numero = EnderecoDTO.Numero,
                UF = EnderecoDTO.UF
            };

            return Endereco;

        }


        public IEnumerable<EnderecoDTO> MapperListEnderecos(IEnumerable<Endereco> Enderecos)
        {
            foreach (var item in Enderecos)
            {


                EnderecoDTO EnderecoDTO = new EnderecoDTO
                {
                    Bairro = item.Bairro,
                    CEP = item.CEP,
                    Complemento = item.Complemento,
                    Id = item.Id,
                    Logradouro = item.Logradouro,
                    Municipio = item.Municipio,
                    Numero = item.Numero,
                    UF = item.UF
                };



                EnderecoDTOs.Add(EnderecoDTO);

            }

            return EnderecoDTOs;
        }

        public EnderecoDTO MapperToDTO(Endereco Endereco)
        {

            EnderecoDTO EnderecoDTO = new EnderecoDTO
            {
                Bairro = Endereco.Bairro,
                CEP = Endereco.CEP,
                Complemento = Endereco.Complemento,
                Id = Endereco.Id,
                Logradouro = Endereco.Logradouro,
                Municipio = Endereco.Municipio,
                Numero = Endereco.Numero,
                UF = Endereco.UF
            };

            return EnderecoDTO;

        }

        #endregion

    }
}
