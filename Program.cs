using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using STI_Entrevista_03_03_2025.CQRS.Commands;
using STI_Entrevista_03_03_2025.CQRS.DTOs;
using STI_Entrevista_03_03_2025.CQRS.Handlers.Commands;
using STI_Entrevista_03_03_2025.CQRS.Handlers.Queries;
using STI_Entrevista_03_03_2025.CQRS.Interfaces;
using STI_Entrevista_03_03_2025.CQRS.Queries;
using STI_Entrevista_03_03_2025.DBModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "X-XSRF-TOKEN";
});

// Adicione a variável à configuração
builder.Configuration["DbContext"] = "SqlServer";

// Função para testar a conexão com o banco de dados
static bool TestDatabaseConnection(string connectionString)
{
    try
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"
                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CadastroVeiculos' AND xtype='U')
                        CREATE TABLE CadastroVeiculos (
                            ID INT PRIMARY KEY IDENTITY,
                            Placa NVARCHAR(10) NOT NULL,
                            Marca NVARCHAR(20) NOT NULL,
                            Modelo NVARCHAR(35) NOT NULL,
                            Cor NVARCHAR(20) NOT NULL,
                            Porte NVARCHAR(20) NOT NULL,
                            Tipo_de_Carga NVARCHAR(20) NOT NULL,
                            Chassis NVARCHAR(20) NOT NULL
                        )";
        command.ExecuteNonQuery();

        connection.Close();

        return true;
    }
    catch
    {
        return false;
    }
}

// Configuração do banco de dados
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Action<DbContextOptionsBuilder> dbContextOptions;

if (TestDatabaseConnection(connectionString))
{
    dbContextOptions = options => options.UseSqlServer(connectionString);
}
else
{
    Console.WriteLine("Erro ao conectar ao SQL Server. Usando banco de dados in-memory.");
    dbContextOptions = options => options.UseInMemoryDatabase("InMemoryDb");
    builder.Configuration["DbContext"] = "InMemoryDb";
}

// Adiciona o contexto do banco de dados com a configuração apropriada
builder.Services.AddDbContext<IEntrevista_03_03_2025Context, Entrevista_03_03_2025Context>(dbContextOptions);


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
