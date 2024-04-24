using Back.PagLigeiro.Domain.Generics;
using Back.PagLigeiro.Util.Validation.Error;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Back.PagLigeiro.Api.Controllers.Error.Model
{
    public class ErrorResponse
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string TraceId { get; set; }
        public Dictionary<string, List<string>>? Errors { get; set; }

        public ErrorResponse()
        { }

        public ErrorResponse(string type = null, string title = null, int status = 400, string traceId = null)
        {
            Type =  !String.IsNullOrEmpty(type) 
                    ? type
                    : "https://tools.ietf.org/html/rfc7231#section-6.5.1";

            Title = !String.IsNullOrEmpty(title) 
                    ? title 
                    : "One or more validation errors occurred.";

            Status = status;
            TraceId = Activity.Current?.Id;
        }

        public ErrorResponse(List<FildErrorReturn> validation)
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
            Title = "One or more validation errors occurred.";
            Status = 400;
            TraceId = Activity.Current?.Id;

            Errors = new Dictionary<string, List<string>>();

            foreach (var erro in validation)
            {
                Errors.Add(erro.Field, new List<string> { erro.Message });
            }
        }
    }
}
