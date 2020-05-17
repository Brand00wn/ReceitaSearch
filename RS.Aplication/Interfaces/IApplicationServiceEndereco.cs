using RS.Application.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Aplication.Interfaces
{
    public interface IApplicationServiceEndereco
    {
        void Add(EnderecoDTO obj);

        EnderecoDTO GetById(int id);

        IEnumerable<EnderecoDTO> GetAll();

        void Update(EnderecoDTO obj);

        void Remove(EnderecoDTO obj);

        void Dispose();

    }
}
