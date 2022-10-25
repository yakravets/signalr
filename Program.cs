using BlazorServerSignalRApp.Data;
using BlazorServerSignalRApp.Server.Hubs;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region snippet_ConfigureServices
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<ProductService>();
builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
});

builder.Services.AddResponseCompression(opts =>
{
	opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
		new[] { "application/octet-stream" });
});

builder.Services.AddCors(action =>
  action.AddPolicy("CorsPolicy", builder =>
    builder
     .AllowAnyMethod()
     .AllowAnyHeader()
     .AllowAnyOrigin()));
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
#region snippet_Configure
app.UseResponseCompression();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors("CorsPolicy");
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapHub<ChatHub>("/api/hubs/chathub", opt =>
{
    opt.Transports =
        HttpTransportType.WebSockets;
});

app.MapFallbackToPage("/_Host");

app.Run();
#endregion
