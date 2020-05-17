using RS.Application.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Aplication.Interfaces
{
    public interface IApplicationServiceQSA
    {
        void Add(QSADTO obj);

        QSADTO GetById(int id);

        IEnumerable<QSADTO> GetAll();

        void Update(QSADTO obj);

        void Remove(QSADTO obj);

        void Dispose();

    }
}
