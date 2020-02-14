using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestServices.Services
{
    public class MessageMiddleware
    {
        private readonly RequestDelegate requestDelegate;
        public MessageMiddleware(RequestDelegate request)
        {
            requestDelegate = request;
        }
        public async Task InvokeAsync(HttpContext context, IMessageSender messageSender)
        {
            context.Response.ContentType = "text/html;charset=utf-8";
            await context.Response.WriteAsync(messageSender.Send());
        }
    }
}
