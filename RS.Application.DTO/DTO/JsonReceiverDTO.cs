using RS.Application.DTO.DTO;
using RS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RS.Application.DTO.DTO
{
    public class JsonReceiverDTO
    {
        public List<AtividadeJson> atividade_principal { get; set; }
        public string data_situacao { get; set; }
        public string complemento { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public List<QSAJson> qsa { get; set; }
        public string situacao { get; set; }
        public string bairro { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string cep { get; set; }
        public string municipio { get; set; }
        public string porte { get; set; }
        public string abertura { get; set; }
        public string natureza_juridica { get; set; }
        public string fantasia { get; set; }
        public string cnpj { get; set; }
        public DateTime ultima_atualizacao { get; set; }
        public string status { get; set; }
        public string tipo { get; set; }
        public string efr { get; set; }
        public string motivo_situacao { get; set; }
        public string situacao_especial { get; set; }
        public string data_situacao_especial { get; set; }
        public List<AtividadeJson> atividades_secundarias { get; set; }
        public string capital_social { get; set; }

        #region Conversão de Json p/ normalização de dados
        public EntidadeDTO LoadEntidadeJson(JsonReceiverDTO obJson)
        {
            EntidadeDTO objLoaded = new EntidadeDTO();

            objLoaded.CapitalSocial = Convert.ToDecimal(obJson.capital_social);
            objLoaded.CNPJ = obJson.cnpj;
            objLoaded.DtAbertura = DateTime.ParseExact(obJson.abertura, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            objLoaded.DtSituacao = DateTime.ParseExact(obJson.data_situacao, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            objLoaded.DtSituacaoEspecial = !String.IsNullOrEmpty(obJson.data_situacao_especial) ? Convert.ToDateTime(obJson.data_situacao_especial) : (DateTime?)null;
            objLoaded.DtUltimaAtualizacao = obJson.ultima_atualizacao;
            objLoaded.EFR = obJson.efr;
            objLoaded.Email = obJson.email;
            objLoaded.Endereco = LoadEnderecoJson(obJson);
            objLoaded.Fantasia = obJson.fantasia;
            objLoaded.MotivoSituacao = obJson.motivo_situacao;
            objLoaded.NaturezaJuridica = obJson.natureza_juridica;
            objLoaded.Nome = obJson.nome;
            objLoaded.Porte = obJson.porte;
            objLoaded.QSA = LoadQSAJson(obJson.qsa);
            objLoaded.Situacao = obJson.situacao;
            objLoaded.SituacaoEspecial = obJson.situacao_especial;
            objLoaded.Status = obJson.status;
            objLoaded.Telefone = obJson.telefone;
            objLoaded.Tipo = obJson.tipo;
            objLoaded.AtividadePrincipal = LoadAtividadePrincipalJson(obJson.atividade_principal);
            objLoaded.AtividadeSecundaria = LoadAtividadeSecundariaJson(obJson.atividades_secundarias);
            objLoaded.Ativo = true;

            return objLoaded;
        }

        private List<EntidadeAtividadePrincipal> LoadAtividadePrincipalJson(List<AtividadeJson> obJson)
        {
            List<EntidadeAtividadePrincipal> atividadePrincipal = new List<EntidadeAtividadePrincipal>();
            List<Atividade> atividade = new List<Atividade>();

            foreach (var a in obJson)
            {
                atividadePrincipal.Add(new EntidadeAtividadePrincipal
                {
                    Atividade = new Atividade { Text = a.text, Code = a.code },
                });
            }

            return atividadePrincipal;
        }

        private List<EntidadeAtividadeSecundaria> LoadAtividadeSecundariaJson(List<AtividadeJson> obJson)
        {
            List<EntidadeAtividadeSecundaria> atividadeSecundaria = new List<EntidadeAtividadeSecundaria>();
            List<Atividade> atividade = new List<Atividade>();

            foreach (var a in obJson)
            {
                atividadeSecundaria.Add(new EntidadeAtividadeSecundaria
                {
                    Atividade = new Atividade { Text = a.text, Code = a.code },
                });
            }

            return atividadeSecundaria;
        }

        private List<QSA> LoadQSAJson(List<QSAJson> obJson)
        {
            List<QSA> qsa = new List<QSA>();

            foreach (var a in obJson)
            {
                qsa.Add(new QSA() { Nome = a.nome, Qualificacao = a.qual });
            }

            return qsa;
        }

        private Endereco LoadEnderecoJson(JsonReceiverDTO obJson)
        {
            Endereco endereco = new Endereco();

            endereco.Bairro = obJson.bairro;
            endereco.CEP = obJson.cep;
            endereco.Complemento = obJson.complemento;
            endereco.Logradouro = obJson.logradouro;
            endereco.Municipio = obJson.municipio;
            endereco.Numero = obJson.numero;
            endereco.UF = obJson.uf;

            return endereco;
        }
        #endregion

    }

    public class QSAJson
    {
        public string qual { get; set; }
        public string nome { get; set; }
    }

    public class AtividadeJson
    {
        public string code { get; set; }
        public string text { get; set; }
    }
}
