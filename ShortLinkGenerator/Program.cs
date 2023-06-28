using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortLinkGenerator.Database;
using ShortLinkGenerator.Database.Models;
using ShortLinkGenerator.Dtos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Get Connection String
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
ArgumentException.ThrowIfNullOrEmpty(connection);
// Add Database
builder.Services.AddDbContext<ShortLinkContext>(config => config.UseSqlite(connection));

// Chars
string chars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890";

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("api/GenerateUrl", async (UrlDto dto, [FromServices] ShortLinkContext context, HttpContext ctx ) =>
{
    if (Uri.TryCreate(dto.Url, UriKind.Absolute, out Uri result))
    {
        Random rnd = new Random();
        var key = "";
        do
        {
            key = new string(Enumerable.Repeat(chars, 8).Select(x => x[rnd.Next(x.Length)]).ToArray());
        }
        while (await context.Urls.AnyAsync(x => x.ShortUrlCode == key));
        await context.AddAsync<ShortUrl>(new ShortUrl
        {
            Url = dto.Url,
            ShortUrlCode = key
        });
        await context.SaveChangesAsync();
        return Results.Ok($"{ctx.Request.Scheme}://{ctx.Request.Host}/{key}");
    }
    else
    {
        return Results.BadRequest("Invalid Url");
    }
})
.Produces<UrlResponeDto>(StatusCodes.Status200OK, "application/json")
.Produces<string>(StatusCodes.Status400BadRequest, "application/json");

app.MapGet("{key}", async (string key, [FromServices] ShortLinkContext context) =>
{
    var url = await context.Urls.SingleOrDefaultAsync(x => x.ShortUrlCode == key);
    if (url is null)
    {
        return Results.NotFound("short url not found");
    }
    return Results.Redirect(url.Url);
})
.Produces(StatusCodes.Status302Found)
.Produces(StatusCodes.Status404NotFound);

app.Run();

