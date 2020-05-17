using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Application.DTO.DTO
{
    public class AtividadeDTO
    {
        public int Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
