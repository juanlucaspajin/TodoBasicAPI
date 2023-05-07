using Microsoft.EntityFrameworkCore;
using TodoBasicAPI.Data;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TodoBasicAPIContext>(
    options =>
    {
        options.UseMySql(builder.Configuration.GetConnectionString("TodoAPIDB"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));
    }
);

builder.Services.AddMvc(option => option.EnableEndpointRouting = false).AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
