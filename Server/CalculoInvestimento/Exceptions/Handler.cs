using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace CalculoInvestimento.Exceptions
{
    public class Handler
    {
        private readonly RequestDelegate _next;

        public Handler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = error is Domain.Exception ? 
                    (int)HttpStatusCode.BadRequest : 
                    (int)HttpStatusCode.InternalServerError;

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
