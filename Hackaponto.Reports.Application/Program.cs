using Hackaponto.Reports.Application.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSettingsValues(builder.Configuration);
builder.Services.ConfigureDbContexts(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureServices();
builder.Services.ConfigureHelpers();
builder.Services.ConfigureRepositories();
builder.Services.ConfigureUseCases();
await builder.Services.ConfigureAuthentication(builder.Configuration);


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseForwardedHeaders();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
