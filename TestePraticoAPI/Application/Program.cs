using Application.Profiles;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Validators;
using FluentValidation;
using Service.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => x.EnableAnnotations());

builder.Services.AddAutoMapper(typeof(ProdutoProfile));
builder.Services.AddScoped<IValidator<Produto>, ProdutoValidators>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IBaseService<Produto>, BaseService<Produto>>();
builder.Services.AddMyDependencyGroup(builder.Configuration.GetConnectionString("DefaultConnection"));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
