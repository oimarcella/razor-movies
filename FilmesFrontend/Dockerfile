# Usando a imagem do SDK do .NET
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Definir o diretório de trabalho
WORKDIR /src

# Copiar o arquivo .csproj para o contêiner
COPY FilmesFrontend/FilmesFrontend.csproj .

# Restaurar as dependências
RUN dotnet restore FilmesFrontend.csproj

# Copiar todos os arquivos restantes do projeto
COPY FilmesFrontend/ .

# Compilar a aplicação
RUN dotnet publish -c Release -o /app

# Usar a imagem de runtime para a execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

# Definir o diretório de trabalho
WORKDIR /app

# Expor a porta para acesso
EXPOSE 80

# Copiar os arquivos do contêiner de build
COPY --from=build /app .

# Rodar a aplicação Razor
ENTRYPOINT ["dotnet", "FilmesFrontend.dll"]
