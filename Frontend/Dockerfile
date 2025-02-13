# Usando a imagem do SDK do .NET
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Definir o diretório de trabalho para o build
WORKDIR /src

# Copiar o arquivo .csproj do frontend para o contêiner
COPY Frontend/Frontend.csproj ./Frontend/

# Restaurar as dependências
RUN dotnet restore ./Frontend/Frontend.csproj

# Copiar todos os arquivos restantes do projeto para o contêiner
COPY Frontend/. ./Frontend/

# Compilar e publicar a aplicação
RUN dotnet publish ./Frontend/Frontend.csproj -c Release -o /app

# Usar a imagem de runtime para a execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

# Definir o diretório de trabalho para o contêiner final
WORKDIR /app

# Expor a porta para acesso
EXPOSE 8080

# Copiar os arquivos do estágio de build
COPY --from=build /app .

# Rodar a aplicação Razor
ENTRYPOINT ["dotnet", "Frontend.dll"]
