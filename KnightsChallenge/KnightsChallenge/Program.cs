using KnightsChallenge.Services;
using KnightsChallenge.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseSettings>
    (builder.Configuration.GetSection("MongoDBSettings"));

builder.Services.AddSingleton<KnightService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowAnyOrigin");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
