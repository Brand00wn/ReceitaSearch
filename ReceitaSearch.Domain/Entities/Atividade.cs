using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Domain.Entities
{
    public class Atividade : BaseEntity
    {
        public string Text { get; set; }

        public string Code { get; set; }

        public virtual List<EntidadeAtividadePrincipal> EntidadePrincipal { get; set; }
        public virtual List<EntidadeAtividadeSecundaria> EntidadeSecundaria { get; set; }
    }
}
