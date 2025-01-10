# FilmesAPI

Este projeto é um **ASP.NET Web API** para gerenciar filmes, desenvolvida em C# com ASP.NET Core. A API permite operações de CRUD para filmes e utiliza o AutoMapper para mapear dados entre diferentes modelos.


### Tecnologias Utilizadas
- ASP.NET Core
- Entity Framework Core
- AutoMapper
- Swagger

### Endpoints

A API disponibiliza endpoints para operações de CRUD (Create, Read, Update, Delete) nos filmes. Você pode usar o Swagger para testar os endpoints.
A base da url da API está configurada, localmente, em `https://localhost:7037/`.

### Como Executar

1. Clone o repositório.
2. Configure as conexões de banco de dados em `appsettings.json`.
3. Execute o comando abaixo para aplicar as migrações e criar o banco de dados:
   ```bash
   dotnet ef database update   
4. Execute o comando abaixo  para dar start na aplicação:
   ```bash
   dotnet run

   

# Outras Informações 

### Swagger
A página para consulta da documentação da API fica em http://localhost:<SUA_PORTA>/swagger no meu caso http://localhost:7037/swagger

![Documentação via Swagger](./print-swagger.png)

### Configuração de Arquivos de Ambiente:**
   - Foi implementado o uso de arquivos **appsettings.json** separados para diferentes ambientes (`Development`e `Production`.).
   - Um exemplo de configuração foi adicionado em `appsettings.Example.json` para servir de template para a configuração sem expor dados sensíveis.

### Proteção de Dados Sensíveis 
   - Os arquivos `appsettings.json` e `appsettings.Development.json` foram adicionados ao `.gitignore` para evitar que informações sensíveis, como strings de conexão, sejam enviadas ao repositório.

### Popular Banco de Dados
   - Criado um script SQL para popular a tabela **Filmes** com registros iniciais (pensado mais para o banco local). O arquivo pode ser encontrado em `FilmesAPI/SeedSql.sql`.
