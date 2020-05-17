using ReceitaSearch.Domain.Core.Interfaces.Services;
using ReceitaSearch.Infra.CrossCutting;
using RS.Aplication.Interfaces;
using RS.Application.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Aplication.Service
{
    public class ApplicationServiceEndereco : IApplicationServiceEndereco
    {
        private readonly IServiceEndereco _serviceEndereco;
        private readonly IMapperEndereco _mapperEndereco;

        public ApplicationServiceEndereco(IServiceEndereco ServiceEndereco, IMapperEndereco MapperEndereco)

        {
            _serviceEndereco = ServiceEndereco;
            _mapperEndereco = MapperEndereco;
        }


        public void Add(EnderecoDTO obj)
        {
            var objEndereco = _mapperEndereco.MapperToEntity(obj);
            _serviceEndereco.Add(objEndereco);
        }

        public void Dispose()
        {
            _serviceEndereco.Dispose();
        }

        public IEnumerable<EnderecoDTO> GetAll()
        {
            var objProdutos = _serviceEndereco.GetAll();
            return _mapperEndereco.MapperListEnderecos(objProdutos);
        }

        public EnderecoDTO GetById(int id)
        {
            var objEndereco = _serviceEndereco.GetById(id);
            return _mapperEndereco.MapperToDTO(objEndereco);
        }

        public void Remove(EnderecoDTO obj)
        {
            var objEndereco = _mapperEndereco.MapperToEntity(obj);
            _serviceEndereco.Remove(objEndereco);
        }

        public void Update(EnderecoDTO obj)
        {
            var objEndereco = _mapperEndereco.MapperToEntity(obj);
            _serviceEndereco.Update(objEndereco);
        }
    }
}
