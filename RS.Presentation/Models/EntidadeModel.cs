using RS.Application.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS.Presentation.Models
{
    public class EntidadeModel
    {
        public List<EntidadeDTO> Entidades { get; set; }

        public string message { get; set; }

        public string dtProximaRequisicao { get; set; }
    }
}
