using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Domain.Entities
{
    public class Endereco : BaseEntity
    {
        public string UF { get; set; }

        public string Municipio { get; set; }

        public string Bairro { get; set; }

        public string Logradouro { get; set; }

        public string CEP { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public virtual Entidade Entidade { get; set; }
    }
}
