using Lib.AspNetCore.ServerSentEvents;
using ServerSentEvents.Net.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register default ServerSentEventsService.
builder.Services.AddServerSentEvents();

// Registers custom ServerSentEventsService which will be used by second middleware, otherwise they would end up sharing connected users.
builder.Services.AddServerSentEvents<IServerSentEventsService, ReportServerSentEventsService>(options =>
{
    options.ReconnectInterval = 5000;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseEndpoints(endpoints => endpoints.MapServerSentEvents<ReportServerSentEventsService>("/sse-report"));

app.Run();
