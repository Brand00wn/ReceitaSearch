using RS.Application.DTO.DTO;
using RS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Infra.CrossCutting.Adapter.Interfaces
{
    public interface IMapperQSA
    {
        #region Mappers

        QSA MapperToEntity(QSADTO QSADTO);

        IEnumerable<QSADTO> MapperListQSAs(IEnumerable<QSA> QSAs);

        QSADTO MapperToDTO(QSA QSA);

        #endregion

    }
}
