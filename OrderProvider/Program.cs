using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using OrderProvider.Data;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
var vaultUrl = new Uri(builder.Configuration["KeyVaultUrl"]!);

builder.Configuration.AddAzureKeyVault(vaultUrl, new DefaultAzureCredential());
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySQL(builder.Configuration["EmailProviderConnectionString"]!);
});

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference(options =>
{
    options.WithTitle("Gross & Sörén")
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
        .WithTheme(ScalarTheme.Mars);
});
app.UseHttpsRedirection();
app.MapGet("/orders", async (DataContext context) =>
{
    var orders = await context.Orders.ToListAsync();
    return Results.Ok(orders);
})
.WithName("GetOrders");

app.MapGet("/order/{id}", async (DataContext context, string id) =>
    {
        var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        return order == null ? Results.NotFound("Lol") : Results.Ok(order);
    })
    .WithName("GetOrder");

app.Run();

public record Order
{
    public string Id { get; set; }
    public string Name { get; set; }
}