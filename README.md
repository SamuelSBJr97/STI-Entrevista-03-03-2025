# STI-Entrevista-03-03-2025

O projeto foi feito no `Visual Studio 2022` com: `.NET 8`, `C#`, `MVC` e `Entity Framework`.

## Dependências

É necessário ter uma conexão com o SGDB `SQL Server` e o nome do banco de dados ser `STI_Entrevista_03_03_2025`.

Além disso, é necessário alterar a conexão do banco de dados no arquivo [appsettings.json](./appsettings.json).

```json
...
"ConnectionStrings": {
    "DefaultConnection": "Server=DESKTOP-ATNAJ0G\\SQLEXPRESS;Database=STI_Entrevista_03_03_2025;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
},
...
```

Caso não seja possível conexão com o `SQL Server`, será instanciado o banco de dados `InMemoryDb`.

## Iniciar a build feita para o `Windows`

### Opção 1

Faça download do projeto e inicie a executavel em: `STI-Entrevista-03-03-2025\publish\STI-Entrevista-03-03-2025.exe`.

### Opção 2

Baixe o arquivo ZIP em [v1.0.0](https://github.com/SamuelSBJr97/STI-Entrevista-03-03-2025/releases/tag/v1.0.0) e execute o arquivo `STI-Entrevista-03-03-2025.exe`.

## Abrir o projeto no `Visual Studio`

Faça download do projeto e abra a solução `STI-Entrevista-03-03-2025\STI-Entrevista-03-03-2025.sln`.