using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RS.Aplication.Interfaces;
using RS.Application.DTO.DTO;
using RS.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

        public IActionResult Index(EntidadeModel model)
        {
            if (TempData.Peek("dtProximaRequisicao") != null && TempData.Peek("requestBlocked") != null)
            {
                ViewData["dtProximaRequisicao"] = TempData.Peek("dtProximaRequisicao").ToString();
            }

            model.Entidades = _applicationServiceEntidade.GetAll().ToList();

            return View("Index", model);
        }

        /// <summary>
        /// Submits form, get the input text value masked as CNPJ and send it as parameter to ReceitaWS request
        /// </summary>
        /// <returns></returns>
        public IActionResult SubmitForm()
        {
            EntidadeModel model = new EntidadeModel();
            var cnpj = Request.Form["cnpj"];

            if (!String.IsNullOrEmpty(cnpj))
            {
                cnpj = Regex.Replace(cnpj, "[^0-9]", "");

                var entidade = Task.Run(async () => await _applicationServiceEntidade.RequestAPI(cnpj));
                

                if (entidade.Result != null)
                {
                    if (TempData.Peek("dtProximaRequisicao") == null)
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

                    if (entidade.Result.statusCode.Equals(HttpStatusCode.OK))
                    {
                        if(entidade.Result.message == null)
                        {
                            _applicationServiceEntidade.Add(entidade.Result.entidade);
                            model.Entidades = _applicationServiceEntidade.GetAll().ToList();
                        }
                        else
                        {
                            model.message = entidade.Result.message;
                        }
                    }
                    else if(entidade.Result.statusCode.Equals(HttpStatusCode.TooManyRequests))
                    {
                        ViewData["dtProximaRequisicao"] = TempData.Peek("dtProximaRequisicao").ToString();
                        TempData["requestBlocked"] = true;
                    }
                    else
                    {
                        model.message = "Erro ao enviar requisição.";
                    }
                }
            }

            return RedirectToAction("Index", model);
        }

        /// <summary>
        /// Redirect to a View with all of relevant details related to this Business Entity.
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        public IActionResult DetalhesEntidade(int entidade)
        {
            EntidadeModel model = new EntidadeModel();
            model.Entidades = new List<EntidadeDTO>();

            model.Entidades.Add(_applicationServiceEntidade.GetById(entidade));

            return View("DetalhesEntidade", model);
        }

        /// <summary>
        /// "Remove" the Business Entity... Actually, just set the "Ativo" field to false. This keeps a history of registered Business Entities  .
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        public IActionResult DeleteEntidade(int entidade)
        {
            EntidadeModel model = new EntidadeModel();
            model.Entidades = new List<EntidadeDTO>();

            try
            {
                EntidadeDTO entidadeDTO = _applicationServiceEntidade.GetById(entidade);

                if(entidadeDTO != null)
                {
                    _applicationServiceEntidade.Remove(entidadeDTO);
                    model.Entidades = _applicationServiceEntidade.GetAll().ToList();
                    model.message = "Registro removido com sucesso.";
                }

                return View("Index", model);
            }
            catch (Exception ex)
            {
                model.Entidades = _applicationServiceEntidade.GetAll().ToList();
                model.message = "Erro ao remover registro.";

                return View("Index", model);
            }
        }

        //Error Page
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
