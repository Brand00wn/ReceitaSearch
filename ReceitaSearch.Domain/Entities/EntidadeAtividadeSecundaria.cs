using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Domain.Entities
{
    public class EntidadeAtividadeSecundaria : BaseEntity
    {
        public int EntidadeId { get; set; }
        public Entidade Entidade { get; set; }


        public int AtividadeId { get; set; }
        public Atividade Atividade { get; set; }
    }
}
