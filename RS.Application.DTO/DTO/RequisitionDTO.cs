using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace RS.Application.DTO.DTO
{
    public class RequisitionDTO
    {
        public EntidadeDTO entidade { get; set; }

        public string message { get; set; }

        public HttpStatusCode statusCode { get; set; }
    }
}
