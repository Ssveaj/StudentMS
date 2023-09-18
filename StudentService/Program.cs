using Core.Interface.UseCases;
using Core.Interfaces;
using Core.Interfaces.UseCases;
using Core.UseCase;
using Infrastructure.Database.Repositories;
using StudentService.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<StudentCommand>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IGetStudentUseCase, GetStudentsUseCase>();
builder.Services.AddScoped<IGetGradeByStudentIdUseCase, GetGradeByStudentIdUseCase>();


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
