using Microsoft.AspNetCore.Builder;

namespace b1
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginMiddleware>();
        }
    }
}