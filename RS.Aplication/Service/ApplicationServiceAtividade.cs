using ReceitaSearch.Domain.Core.Interfaces.Services;
using RS.Aplication.Interfaces;
using RS.Application.DTO.DTO;
using RS.Infra.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Aplication.Service
{
    public class ApplicationServiceAtividade : IApplicationServiceAtividade
    {
        private readonly IServiceAtividade _serviceAtividade;
        private readonly IMapperAtividade _mapperAtividade;

        public ApplicationServiceAtividade(IServiceAtividade ServiceAtividade, IMapperAtividade MapperAtividade)

        {
            _serviceAtividade = ServiceAtividade;
            _mapperAtividade = MapperAtividade;
        }


        public void Add(AtividadeDTO obj)
        {
            var objAtividade = _mapperAtividade.MapperToEntity(obj);
            _serviceAtividade.Add(objAtividade);
        }

        public void Dispose()
        {
            _serviceAtividade.Dispose();
        }

        public IEnumerable<AtividadeDTO> GetAll()
        {
            var objProdutos = _serviceAtividade.GetAll();
            return _mapperAtividade.MapperListAtividades(objProdutos);
        }

        public AtividadeDTO GetById(int id)
        {
            var objAtividade = _serviceAtividade.GetById(id);
            return _mapperAtividade.MapperToDTO(objAtividade);
        }

        public void Remove(AtividadeDTO obj)
        {
            var objAtividade = _mapperAtividade.MapperToEntity(obj);
            _serviceAtividade.Remove(objAtividade);
        }

        public void Update(AtividadeDTO obj)
        {
            var objAtividade = _mapperAtividade.MapperToEntity(obj);
            _serviceAtividade.Update(objAtividade);
        }
    }
}
