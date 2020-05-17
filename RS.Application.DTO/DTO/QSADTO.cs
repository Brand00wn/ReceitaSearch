using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Application.DTO.DTO
{
    public class QSADTO
    {
        public int Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("qual")]
        public string Qualificacao { get; set; }
    }
}
