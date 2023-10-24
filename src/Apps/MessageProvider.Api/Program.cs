using MessageProvider.Api.MessageService.Impl;
using MessageProvider.Api.MessageService.Options;
using MessageProvider.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddOptions<MessageServiceOptions>()
            .Bind(builder.Configuration.GetSection(MessageServiceOptions.Name))
            .ValidateDataAnnotations();
builder.Services.AddTransient<IMessageService, MessageService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
