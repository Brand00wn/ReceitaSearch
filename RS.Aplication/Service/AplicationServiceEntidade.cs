using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReceitaSearch.Domain.Core.Interfaces.Services;
using ReceitaSearch.Infra.CrossCutting;
using RS.Aplication.Interfaces;
using RS.Application.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RS.Aplication.Service
{
    public class ApplicationServiceEntidade : IApplicationServiceEntidade
    {
        private readonly IServiceEntidade _serviceEntidade;
        private readonly IMapperEntidade _mapperEntidade;

        public ApplicationServiceEntidade(IServiceEntidade ServiceEntidade, IMapperEntidade MapperEntidade)

        {
            _serviceEntidade = ServiceEntidade;
            _mapperEntidade = MapperEntidade;
        }


        public void Add(EntidadeDTO obj)
        {
            var objEntidade = _mapperEntidade.MapperToEntity(obj);
            var entidadeCadastrada = CheckIfAlreadyExists(obj);
            if (entidadeCadastrada == null)
            {
                _serviceEntidade.Add(objEntidade);
            }
            else
            {
                if(entidadeCadastrada.Ativo == false)
                {
                    entidadeCadastrada.Ativo = true;
                    _serviceEntidade.Update(_mapperEntidade.MapperToEntity(entidadeCadastrada));
                }
            }
        }

        public void Dispose()
        {
            _serviceEntidade.Dispose();
        }

        public IEnumerable<EntidadeDTO> GetAll()
        {
            var objProdutos = _serviceEntidade.GetAll();
            return _mapperEntidade.MapperListEntidades(objProdutos);
        }

        public EntidadeDTO GetById(int id)
        {
            var objEntidade = _serviceEntidade.GetById(id);
            return _mapperEntidade.MapperToDTO(objEntidade);
        }

        public void Remove(EntidadeDTO obj)
        {
            obj.Ativo = false;
            var objEntidade = _mapperEntidade.MapperToEntity(obj);
            _serviceEntidade.Remove(objEntidade);
        }

        public void Update(EntidadeDTO obj)
        {
            var objEntidade = _mapperEntidade.MapperToEntity(obj);
            _serviceEntidade.Update(objEntidade);
        }

        public EntidadeDTO CheckIfAlreadyExists(EntidadeDTO obj)
        {
            var objEntidade = _mapperEntidade.MapperToEntity(obj);
            var entidadeCadastrada = _serviceEntidade.CheckIfAlreadyExists(objEntidade);

            if(entidadeCadastrada != null)
            {
                return _mapperEntidade.MapperToDTO(entidadeCadastrada);
            }
            else
            {
                return null;
            }
        }

        public async Task<RequisitionDTO> RequestAPI(string cnpj)
        {
            RequisitionDTO model = new RequisitionDTO();
            HttpClient client = new HttpClient();

            try
            {

                HttpResponseMessage response = await client.GetAsync($"https://www.receitaws.com.br/v1/cnpj/{cnpj}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    JsonReceiverDTO obJson = JsonConvert.DeserializeObject<JsonReceiverDTO>(json);
                    if (obJson.status == "OK")
                    {
                        model.entidade = new EntidadeDTO();
                        model.entidade = obJson.LoadEntidadeJson(obJson);
                        model.statusCode = response.StatusCode;
                    }
                    else
                    {
                        dynamic jObject = JObject.Parse(json);
                        model.statusCode = response.StatusCode;
                        model.message = jObject.message;
                    }

                    return model;
                }
                else
                {
                    model.statusCode = response.StatusCode;
                    model.message = response.RequestMessage.ToString();
                    return model;
                }
            }
            catch (Exception ex)
            {
                model.message = "Erro na requisição.";
                return model;
            }
        }
    }
}
