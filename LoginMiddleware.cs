using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace b1
{
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;
        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            string log = "Schema: " + request.Scheme
                            + "\nHost: " + request.Host
                            + "\nPath: " + request.Path
                            + "\nQuery string: " + request.QueryString
                            + "\nRequest body: " + request.Body;

            Debug.Write(log);

            using (var buffer = new MemoryStream(Encoding.ASCII.GetBytes(log)))
            {
                await _next(context);

                using (FileStream file = new FileStream("file.txt", FileMode.Create, System.IO.FileAccess.Write))
                    await buffer.CopyToAsync(file);
            }
        }
    }
}