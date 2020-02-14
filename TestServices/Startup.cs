using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestServices.Services;

namespace TestServices
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        //private IServiceCollection serviceDescriptors;
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMessageSender, SMSMessageSender>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IHostEnvironment env, IMessageSender  messageSender)//(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IMessageSender messageSender)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(messageSender.Send());
            });
        }
        //app.Run(async context =>
        //{
        //    var sb = new StringBuilder();
        //    sb.Append("<h1> All services</h1>");
        //    sb.Append("<table border=1px>");
        //    sb.Append("<tr><th>Тип</th><th>Lifetime</th><th>Реализация</th></tr>");
        //    foreach (var svc in serviceDescriptors)
        //    {
        //        sb.Append("<tr>");
        //        sb.Append($"<td>{svc.ServiceType.FullName}</td>");
        //        sb.Append($"<td>{svc.Lifetime}</td>");
        //        sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
        //        sb.Append("</tr>");
        //    }
        //    sb.Append("</table>");
        //    context.Response.ContentType = "text/html;charset=utf-8";
        //    await context.Response.WriteAsync(sb.ToString());
        //});
        //}
    }
}
