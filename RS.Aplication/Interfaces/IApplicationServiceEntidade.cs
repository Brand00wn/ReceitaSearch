﻿using RS.Application.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RS.Aplication.Interfaces
{
    public interface IApplicationServiceEntidade
    {
        void Add(EntidadeDTO obj);

        EntidadeDTO GetById(int id);

        IEnumerable<EntidadeDTO> GetAll();

        void Update(EntidadeDTO obj);

        void Remove(EntidadeDTO obj);

        void Dispose();

        EntidadeDTO CheckIfAlreadyExists(EntidadeDTO obj);

        Task<RequisitionDTO> RequestAPI(string cnpj);

    }
}
