using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Application.DTO.DTO
{
    public class EnderecoDTO
    {
        public int Id { get; set; }

        public string UF { get; set; }

        public string Municipio { get; set; }

        public string Bairro { get; set; }

        public string Logradouro { get; set; }

        public string CEP { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }
    }
}
