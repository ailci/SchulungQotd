using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SchulungQotd.WebApi.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ApiKeyAttribute(IConfiguration configuration) : Attribute, IAuthorizationFilter
    {
        private const string API_KEY_NAME = "x-api-key";

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var apiKeyPresentInHeader = context.HttpContext.Request.Headers.TryGetValue(API_KEY_NAME, out var extractedApiKey);
            var apiKeyConfig = configuration.GetValue<string>("XApiKey");

            if (apiKeyPresentInHeader && extractedApiKey.Equals(apiKeyConfig) ||
                context.HttpContext.Request.Path.StartsWithSegments("/swagger"))
            {
                return;
            }

            context.Result = new UnauthorizedResult();
        }
    }
}
