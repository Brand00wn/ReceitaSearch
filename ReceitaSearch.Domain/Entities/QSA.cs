using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Domain.Entities
{
    public class QSA : BaseEntity
    {
        public string Nome { get; set; }

        public string Qualificacao { get; set; }

        public int EntidadeId { get; set; }
        public virtual Entidade Entidade { get; set; }
    }
}
