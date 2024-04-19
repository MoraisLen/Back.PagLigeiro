using Back.PagLigeiro.Util.Validation.Error;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;

namespace Back.PagLigeiro.Api.Controllers.Error.Model
{
    public class ErrorResponse
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string? Message { get; set; }
        public int Status { get; set; }
        public string TraceId { get; set; }
        public Dictionary<string, List<string>>? Errors { get; set; }

        public ErrorResponse()
        {
        }

        public ErrorResponse(string type = null, string title = null, string message = null, int status = 400, string traceId = null)
        {
            Type =  !String.IsNullOrEmpty(type) 
                    ? type
                    : "https://tools.ietf.org/html/rfc7231#section-6.5.1";

            Title = !String.IsNullOrEmpty(title) 
                    ? title 
                    : "One or more validation errors occurred.";

            Message = message;
            Status = status;
            TraceId = traceId;
        }

        public ErrorResponse(ErrorValidation validation, string traceid)
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
            Title = "One or more validation errors occurred.";
            Message = null;
            Status = 400;
            TraceId = traceid;

            Errors = new Dictionary<string, List<string>>();

            foreach (var erro in validation.lstErros)
            {
                Errors.Add(erro.Field, new List<string> { erro.Message });
            }
        }
    }
}
