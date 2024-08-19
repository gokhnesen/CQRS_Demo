using Application.Exceptions.Handlers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HttpExceptionHandler _httpExceptionHandler;

        public ExceptionMiddleware(RequestDelegate next, HttpExceptionHandler httpExceptionHandler)
        {
            _next = next;
            _httpExceptionHandler = new HttpExceptionHandler();
        }

        public async Task Invoke(HttpContext context)
        {

        }
    }
}
