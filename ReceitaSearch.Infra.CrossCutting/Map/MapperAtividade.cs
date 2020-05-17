using RS.Application.DTO.DTO;
using RS.Domain.Entities;
using RS.Infra.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Infra.CrossCutting.Adapter.Map
{
    public class MapperAtividade : IMapperAtividade
    {

        #region properties

        List<AtividadeDTO> atividadeDTOs = new List<AtividadeDTO>();

        #endregion


        #region methods

        public Atividade MapperToEntity(AtividadeDTO atividadeDTO)
        {
            Atividade atividade = new Atividade
            {
                Id = atividadeDTO.Id,
                Code = atividadeDTO.Code,
                Text = atividadeDTO.Text
            };

            return atividade;

        }


        public IEnumerable<AtividadeDTO> MapperListAtividades(IEnumerable<Atividade> atividades)
        {
            foreach (var item in atividades)
            {


                AtividadeDTO atividadeDTO = new AtividadeDTO
                {
                    Id = item.Id,
                    Code = item.Code,
                    Text = item.Text
                };



                atividadeDTOs.Add(atividadeDTO);

            }

            return atividadeDTOs;
        }

        public AtividadeDTO MapperToDTO(Atividade Atividade)
        {

            AtividadeDTO atividadeDTO = new AtividadeDTO
            {
                Id = Atividade.Id,
                Code = Atividade.Code,
                Text = Atividade.Text
            };

            return atividadeDTO;

        }

        #endregion

    }
}
