using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Data;

namespace WebApplication5.Middlewares
{
  // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
  public class DbMiddleware
  {
    private readonly RequestDelegate _next;

    public DbMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public Task Invoke(HttpContext httpContext, [FromServices] App app)
    {
      var customerId = httpContext.Request.Headers["X-Customer-Id"].FirstOrDefault();
      var serverId = httpContext.Request.Headers["X-Server-Id"].FirstOrDefault();

      if (!string.IsNullOrEmpty(customerId))
      {
        var cnString = $"Server=.\\sqlexpres;Database=Db-{customerId};Integrated Security=True;";
        var options = new DbContextOptionsBuilder<AppDb>()
                  .UseSqlServer(cnString)
                  .Options;
        var db = new AppDb(options);

        app.Db = db;
        app.ConnectionString = cnString;
      }

      return _next(httpContext);
    }
  }

  // Extension method used to add the middleware to the HTTP request pipeline.
  public static class DbMiddlewareExtensions
  {
    public static IApplicationBuilder UseDbMiddleware(this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<DbMiddleware>();
    }
  }
}
