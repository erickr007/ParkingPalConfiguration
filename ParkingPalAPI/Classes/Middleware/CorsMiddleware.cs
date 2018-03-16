using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingPalAPI
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class CorsMiddleware
    {
        private readonly RequestDelegate _next;

        public CorsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:4200");
            httpContext.Response.Headers.Add("Access-Control-Allow-Methods", "OPTIONS, GET, POST, PUT, PATCH, DELETE");
            httpContext.Response.Headers.Add("Access-Control-Allow-Headers", "X-PINGOTHER, Content-Type, Authorization");

            await _next(httpContext);
        }
    }

    public static class CorsExtensions
    {
        public static IApplicationBuilder UseCorsMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CorsMiddleware>();

            return app;
        }
    }
}
