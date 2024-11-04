# FilmesAPI

Este projeto � um **ASP.NET Web API** para gerenciar filmes, desenvolvida em C# com ASP.NET Core. A API permite opera��es de CRUD para filmes e utiliza o AutoMapper para mapear dados entre diferentes modelos.


## Tecnologias Utilizadas
- ASP.NET Core
- Entity Framework Core
- AutoMapper
- Swagger

## Swagger
A p�gina para consulta da documenta��o da API fica em http://localhost:<SUA_PORTA>/swagger no meu caso http://localhost:7037/swagger

![Documenta��o via Swagger](./print-swagger.png)


## Estrutura do Projeto

Abaixo est� a estrutura principal do projeto:

- **AutoMapProfiles**: Cont�m os perfis do AutoMapper para mapeamento de objetos, facilitando a convers�o entre entidades e DTOs.
  - `Profiles.cs`: Define as configura��es de mapeamento do AutoMapper.

- **Controllers**
  - `FilmeController.cs`: Controlador principal para as opera��es de CRUD dos filmes.

- **Data**
  - `DataContext.cs`: Classe de contexto do Entity Framework, respons�vel por configurar o banco de dados e definir as DbSets das entidades, como `Filme`.
  - Arquivos de migra��o: Usados para criar e atualizar o esquema do banco de dados.

- **Dtos (Data Transfer Objects)**
  - `CreateFilmeDto.cs`: DTO para cria��o de novos filmes, especificando apenas os campos necess�rios.
  - `UpdateFilmeDto.cs`: DTO para atualiza��o de filmes, permitindo a modifica��o de dados espec�ficos.

- **Models**
  - `Filme.cs`: Modelo principal que representa a entidade Filme.

## Pr�-requisitos

- .NET 6 SDK ou superior
- Entity Framework Core

## Endpoints

A API disponibiliza endpoints para opera��es de CRUD (Create, Read, Update, Delete) nos filmes. Voc� pode usar o Swagger para testar os endpoints.

## Como Executar

1. Clone o reposit�rio.
2. Configure as conex�es de banco de dados em `appsettings.json`.
3. Execute o comando abaixo para aplicar as migra��es e criar o banco de dados:
   ```bash
   dotnet ef database update   
4. Execute o comando abaixo  para dar start na aplica��o:
   ```bash
   dotnet run
