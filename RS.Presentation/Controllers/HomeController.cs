using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RS.Aplication.Interfaces;
using RS.Application.DTO.DTO;
using RS.Domain.Entities;
using RS.Presentation.Models;

namespace RS.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IApplicationServiceEntidade _applicationServiceEntidade;

        public HomeController(ILogger<HomeController> logger, IApplicationServiceEntidade applicationServiceEntidade)
        {
            _applicationServiceEntidade = applicationServiceEntidade;
            _logger = logger;
        }

        public async Task<EntidadeModel> RequestAPI(string cnpj)
        {
            EntidadeModel model = new EntidadeModel();
            HttpClient client = new HttpClient();

            try
            {
                
                HttpResponseMessage response = await client.GetAsync($"https://www.receitaws.com.br/v1/cnpj/{cnpj}");
                if(TempData.Peek("dtProximaRequisicao") == null)
                {
                    TempData["dtProximaRequisicao"] = DateTime.Now.AddMinutes(1);
                }
                else
                {
                    if (DateTime.Now.Subtract(Convert.ToDateTime(TempData.Peek("dtProximaRequisicao"))).TotalSeconds >= 0)
                    {
                        TempData.Remove("dtProximaRequisicao");
                    }
                }

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    JsonReceiver obJson = JsonConvert.DeserializeObject<JsonReceiver>(json);
                    if (obJson.status == "OK")
                    {
                        model.Entidades = new List<EntidadeDTO>();
                        model.Entidades.Add(obJson.LoadEntidadeJson(obJson));
                        model.message = "OK";
                    }
                    else
                    {
                        dynamic jObject = JObject.Parse(json);
                        model.message = jObject.message;
                    }

                    return model;
                }
                else if (response.StatusCode.Equals(HttpStatusCode.TooManyRequests))
                {
                    model.dtProximaRequisicao = TempData.Peek("dtProximaRequisicao").ToString();
                    return model;
                }
                else
                {
                    model.message = "Erro ao tentar acessar o endereço.";
                    return model;
                }
            }
            catch (Exception ex)
            {
                model.message = "Erro na requisição.";
                return model;
            }
        }

        public IActionResult SubmitForm()
        {
            EntidadeModel model = new EntidadeModel();
            var cnpj = Request.Form["cnpj"];

            if (!String.IsNullOrEmpty(cnpj))
            {
                cnpj = Regex.Replace(cnpj, "[^0-9]", "");

                var entidade = Task.Run(async () => await RequestAPI(cnpj));

                if (entidade.Result != null)
                {
                    if (entidade.Result.message == "OK")
                    {
                        _applicationServiceEntidade.Add(entidade.Result.Entidades.FirstOrDefault());
                        model.Entidades = _applicationServiceEntidade.GetAll().ToList();
                    }
                    else
                    {
                        model.dtProximaRequisicao = entidade.Result.dtProximaRequisicao;
                        model.message = entidade.Result.message;
                    }
                }
            }

            return RedirectToAction("Index", model);
        }

        public IActionResult Index(EntidadeModel model)
        {
            model.Entidades = _applicationServiceEntidade.GetAll().ToList();

            return View("Index", model);
        }

        public IActionResult DetalhesEntidade(int entidade)
        {
            EntidadeModel model = new EntidadeModel();
            model.Entidades = new List<EntidadeDTO>();

            model.Entidades.Add(_applicationServiceEntidade.GetById(entidade));

            return View("DetalhesEntidade", model);
        }

        public IActionResult DeleteEntidade(int entidade)
        {
            EntidadeModel model = new EntidadeModel();
            model.Entidades = new List<EntidadeDTO>();

            try
            {
                EntidadeDTO entidadeDTO = _applicationServiceEntidade.GetById(entidade);
                entidadeDTO.Ativo = false;
                _applicationServiceEntidade.Update(entidadeDTO);
                model.Entidades = _applicationServiceEntidade.GetAll().ToList();
                model.message = "Registro removido com sucesso.";

                return View("Index", model);
            }
            catch (Exception ex)
            {
                model.Entidades = _applicationServiceEntidade.GetAll().ToList();
                model.message = "Erro ao remover registro.";

                return View("Index", model);
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
