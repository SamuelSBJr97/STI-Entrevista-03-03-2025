using STI_Entrevista_03_03_2025.CQRS.Commands;
using STI_Entrevista_03_03_2025.CQRS.DTOs;
using STI_Entrevista_03_03_2025.CQRS.Handlers.Commands;
using STI_Entrevista_03_03_2025.CQRS.Handlers.Queries;
using STI_Entrevista_03_03_2025.CQRS.Interfaces;
using STI_Entrevista_03_03_2025.CQRS.Queries;
using STI_Entrevista_03_03_2025.DBModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "X-XSRF-TOKEN";
});

// Adiciona o contexto do banco de dados
builder.Services.AddDbContext<IEntrevista_03_03_2025Context, Entrevista_03_03_2025Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registra os handlers de comandos
builder.Services.AddScoped<ICommandResultHandler<CreateCadastroVeiculoCommand, CadastroVeiculoDto>, CreateCadastroVeiculoCommandHandler>();
builder.Services.AddScoped<ICommandHandler<UpdateCadastroVeiculoCommand>, UpdateCadastroVeiculoCommandHandler>();
builder.Services.AddScoped<ICommandHandler<DeleteCadastroVeiculoCommand>, DeleteCadastroVeiculoHandler>();

// Registra os handlers de consultas
builder.Services.AddScoped<IQueryHandler<GetAllCadastroVeiculosQuery, IEnumerable<CadastroVeiculoDto>>, GetAllCadastroVeiculosHandler>();
builder.Services.AddScoped<IQueryHandler<GetCadastroVeiculoByIdQuery, CadastroVeiculoDto>, GetCadastroVeiculoByIdQueryHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CadastroVeiculo}/{action=Index}/{id?}");

app.Run();
