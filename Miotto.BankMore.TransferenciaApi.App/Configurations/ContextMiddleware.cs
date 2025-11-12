using FluentValidation;
using Miotto.BankMore.TransferenciaApi.Infra.Contexts;
using System.Text.Json;

namespace Miotto.BankMore.TransferenciaApi.App.Configurations
{
    public class ContextMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                var dbContext = context.RequestServices.GetRequiredService<BankMoreTransferenciaContext>();

                await next.Invoke(context);

                await dbContext.SaveChangesAsync();
            }
                catch (ValidationException ex)
                {
                    context.Response.StatusCode = 400;
                    context.Response.ContentType = "application/json";

                    var result = new
                    {
                        Status = 400,
                        Title = "Erro de validação",
                        Detail = "Dados inválidos fornecidos",
                        Errors = ex.Errors.Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage })
                    };

            await context.Response.WriteAsync(JsonSerializer.Serialize(result));
            }
        }
    }
}
