using ReceitaSearch.Domain.Core.Interfaces.Services;
using RS.Aplication.Interfaces;
using RS.Application.DTO.DTO;
using RS.Infra.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Aplication.Service
{
    public class ApplicationServiceQSA : IApplicationServiceQSA
    {
        private readonly IServiceQSA _serviceQSA;
        private readonly IMapperQSA _mapperQSA;

        public ApplicationServiceQSA(IServiceQSA ServiceQSA, IMapperQSA MapperQSA)

        {
            _serviceQSA = ServiceQSA;
            _mapperQSA = MapperQSA;
        }


        public void Add(QSADTO obj)
        {
            var objQSA = _mapperQSA.MapperToEntity(obj);
            _serviceQSA.Add(objQSA);
        }

        public void Dispose()
        {
            _serviceQSA.Dispose();
        }

        public IEnumerable<QSADTO> GetAll()
        {
            var objProdutos = _serviceQSA.GetAll();
            return _mapperQSA.MapperListQSAs(objProdutos);
        }

        public QSADTO GetById(int id)
        {
            var objQSA = _serviceQSA.GetById(id);
            return _mapperQSA.MapperToDTO(objQSA);
        }

        public void Remove(QSADTO obj)
        {
            var objQSA = _mapperQSA.MapperToEntity(obj);
            _serviceQSA.Remove(objQSA);
        }

        public void Update(QSADTO obj)
        {
            var objQSA = _mapperQSA.MapperToEntity(obj);
            _serviceQSA.Update(objQSA);
        }
    }
}
