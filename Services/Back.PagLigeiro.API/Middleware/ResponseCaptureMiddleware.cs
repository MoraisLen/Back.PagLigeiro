using Back.PagLigeiro.Util.LogHelper;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Back.PagLigeiro.Api.Middleware
{
    public class ResponseCaptureMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly List<int> _statusParaLog = new List<int>
        {
            (int) StatusCodes.Status400BadRequest,
            (int) StatusCodes.Status401Unauthorized
        };

        public ResponseCaptureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Capturar a resposta original
            Stream originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                // Chamada para o próximo middleware
                await _next(context);

                if (_statusParaLog.Any(x => x.Equals(context.Response.StatusCode)))
                {
                    // Capturar a saída ou retorno do método do controller
                    responseBody.Seek(0, SeekOrigin.Begin);
                    string responseBodyContent = await new StreamReader(responseBody).ReadToEndAsync();

                    LogHelper.Error(responseBodyContent);
                }

                // Segue para o restante do fluxo
                responseBody.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }
    }
}