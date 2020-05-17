using Newtonsoft.Json;
using RS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Application.DTO.DTO
{
    public class EntidadeDTO
    {
        public int Id { get; set; }

        #region Informações Gerais
        public string Nome { get; set; }

        public string Fantasia { get; set; }

        public string NaturezaJuridica { get; set; }

        public string CNPJ { get; set; }
        #endregion


        #region Informações de Contato
        public string Email { get; set; }

        public string Telefone { get; set; }
        #endregion

        #region Informações Detalhadas
        public string Tipo { get; set; }

        public string Porte { get; set; }

        public string Situacao { get; set; }

        public DateTime DtSituacao { get; set; }

        public DateTime DtAbertura { get; set; }

        public string Status { get; set; }

        public string EFR { get; set; }

        public string MotivoSituacao { get; set; }

        public string SituacaoEspecial { get; set; }

        public DateTime? DtSituacaoEspecial { get; set; }

        public DateTime DtUltimaAtualizacao { get; set; }

        public decimal CapitalSocial { get; set; }

        public virtual List<EntidadeAtividadePrincipal> AtividadePrincipal { get; set; }

        public virtual List<EntidadeAtividadeSecundaria> AtividadeSecundaria { get; set; }
        #endregion

        #region Informações de Localização
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        #endregion

        #region Informações de Sócios
        public virtual List<QSA> QSA { get; set; }
        #endregion

        public DateTime DtInsercaoBanco { get; set; }

        public bool Ativo { get; set; }
    }
}
