using HotChocolate.Authorization;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddAuthorization()
    .AddAuthentication();

builder.Services
    .AddGraphQLServer()
    .AddAuthorization()
    .AddQueryType<Query>();

var app = builder.Build();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapGraphQL();

app.Run();

public class Book
{
    public string Title { get; set; }
}

[Authorize]
public class Query
{
    public Book GetBook() =>
        new Book
        {
            Title = "C# in depth.",
        };
}
