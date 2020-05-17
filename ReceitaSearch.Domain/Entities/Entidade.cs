using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RS.Domain.Entities
{
    public class Entidade : BaseEntity
    {
        public string Nome { get; set; }

        public string Fantasia { get; set; }

        public string NaturezaJuridica { get; set; }

        public string CNPJ { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

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

        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }

        public virtual List<QSA> QSA { get; set; }


        public DateTime DtInsercaoBanco { get; set; }

        public bool Ativo { get; set; }
    }
}
