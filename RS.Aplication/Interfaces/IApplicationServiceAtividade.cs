using RS.Application.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Aplication.Interfaces
{
    public interface IApplicationServiceAtividade
    {
        void Add(AtividadeDTO obj);

        AtividadeDTO GetById(int id);

        IEnumerable<AtividadeDTO> GetAll();

        void Update(AtividadeDTO obj);

        void Remove(AtividadeDTO obj);

        void Dispose();

    }
}
