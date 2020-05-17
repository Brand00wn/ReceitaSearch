using RS.Application.DTO.DTO;
using RS.Domain.Entities;
using RS.Infra.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Infra.CrossCutting.Adapter.Map
{
    public class MapperQSA : IMapperQSA
    {

        #region properties

        List<QSADTO> qsaDTOs = new List<QSADTO>();

        #endregion


        #region methods

        public QSA MapperToEntity(QSADTO qsaDTO)
        {
            QSA qsa = new QSA
            {
                Id = qsaDTO.Id,
                Nome = qsaDTO.Nome,
                Qualificacao = qsaDTO.Qualificacao
            };

            return qsa;

        }


        public IEnumerable<QSADTO> MapperListQSAs(IEnumerable<QSA> qsas)
        {
            foreach (var item in qsas)
            {


                QSADTO qsaDTO = new QSADTO
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Qualificacao = item.Qualificacao
                };



                qsaDTOs.Add(qsaDTO);

            }

            return qsaDTOs;
        }

        public QSADTO MapperToDTO(QSA QSA)
        {

            QSADTO qsaDTO = new QSADTO
            {
                Id = QSA.Id,
                Nome = QSA.Nome,
                Qualificacao = QSA.Qualificacao
            };

            return qsaDTO;

        }

        #endregion

    }
}
