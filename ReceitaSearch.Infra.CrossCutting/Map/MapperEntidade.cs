using ReceitaSearch.Infra.CrossCutting;
using RS.Application.DTO.DTO;
using RS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Infra.CrossCutting.Adapter.Map
{
    public class MapperEntidade : IMapperEntidade
    {

        #region properties

        List<EntidadeDTO> EntidadeDTOs = new List<EntidadeDTO>();

        #endregion


        #region methods

        public Entidade MapperToEntity(EntidadeDTO EntidadeDTO)
        {
            Entidade Entidade = new Entidade
            {
                AtividadePrincipal = EntidadeDTO.AtividadePrincipal,
                AtividadeSecundaria = EntidadeDTO.AtividadeSecundaria,
                CapitalSocial = EntidadeDTO.CapitalSocial,
                CNPJ = EntidadeDTO.CNPJ,
                DtAbertura = EntidadeDTO.DtAbertura,
                DtSituacao = EntidadeDTO.DtSituacao,
                DtSituacaoEspecial = EntidadeDTO.DtSituacaoEspecial,
                DtUltimaAtualizacao = EntidadeDTO.DtUltimaAtualizacao,
                EFR = EntidadeDTO.EFR,
                Email = EntidadeDTO.Email,
                Endereco = EntidadeDTO.Endereco,
                Fantasia = EntidadeDTO.Fantasia,
                Id = EntidadeDTO.Id,
                MotivoSituacao = EntidadeDTO.MotivoSituacao,
                NaturezaJuridica = EntidadeDTO.NaturezaJuridica,
                Nome = EntidadeDTO.Nome,
                Porte = EntidadeDTO.Porte,
                QSA = EntidadeDTO.QSA,
                Situacao = EntidadeDTO.Situacao,
                SituacaoEspecial = EntidadeDTO.SituacaoEspecial,
                Status = EntidadeDTO.Status,
                Telefone = EntidadeDTO.Telefone,
                Tipo = EntidadeDTO.Tipo,
                Ativo = EntidadeDTO.Ativo,
                EnderecoId = EntidadeDTO.EnderecoId
            };

            return Entidade;

        }


        public IEnumerable<EntidadeDTO> MapperListEntidades(IEnumerable<Entidade> Entidades)
        {
            foreach (var item in Entidades)
            {


                EntidadeDTO EntidadeDTO = new EntidadeDTO
                {
                    AtividadePrincipal = item.AtividadePrincipal,
                    AtividadeSecundaria = item.AtividadeSecundaria,
                    CapitalSocial = item.CapitalSocial,
                    CNPJ = item.CNPJ,
                    DtAbertura = item.DtAbertura,
                    DtSituacao = item.DtSituacao,
                    DtSituacaoEspecial = item.DtSituacaoEspecial,
                    DtUltimaAtualizacao = item.DtUltimaAtualizacao,
                    EFR = item.EFR,
                    Email = item.Email,
                    Endereco = item.Endereco,
                    Fantasia = item.Fantasia,
                    Id = item.Id,
                    MotivoSituacao = item.MotivoSituacao,
                    NaturezaJuridica = item.NaturezaJuridica,
                    Nome = item.Nome,
                    Porte = item.Porte,
                    QSA = item.QSA,
                    Situacao = item.Situacao,
                    SituacaoEspecial = item.SituacaoEspecial,
                    Status = item.Status,
                    Telefone = item.Telefone,
                    Tipo = item.Tipo,
                    Ativo = item.Ativo,
                    EnderecoId = item.EnderecoId
                };



                EntidadeDTOs.Add(EntidadeDTO);

            }

            return EntidadeDTOs;
        }

        public EntidadeDTO MapperToDTO(Entidade Entidade)
        {

            EntidadeDTO EntidadeDTO = new EntidadeDTO
            {
                AtividadePrincipal = Entidade.AtividadePrincipal,
                AtividadeSecundaria = Entidade.AtividadeSecundaria,
                CapitalSocial = Entidade.CapitalSocial,
                CNPJ = Entidade.CNPJ,
                DtAbertura = Entidade.DtAbertura,
                DtSituacao = Entidade.DtSituacao,
                DtSituacaoEspecial = Entidade.DtSituacaoEspecial,
                DtUltimaAtualizacao = Entidade.DtUltimaAtualizacao,
                EFR = Entidade.EFR,
                Email = Entidade.Email,
                Endereco = Entidade.Endereco,
                Fantasia = Entidade.Fantasia,
                Id = Entidade.Id,
                MotivoSituacao = Entidade.MotivoSituacao,
                NaturezaJuridica = Entidade.NaturezaJuridica,
                Nome = Entidade.Nome,
                Porte = Entidade.Porte,
                QSA = Entidade.QSA,
                Situacao = Entidade.Situacao,
                SituacaoEspecial = Entidade.SituacaoEspecial,
                Status = Entidade.Status,
                Telefone = Entidade.Telefone,
                Tipo = Entidade.Tipo,
                Ativo = Entidade.Ativo,
                EnderecoId = Entidade.EnderecoId
            };

            return EntidadeDTO;

        }

        #endregion

    }
}
