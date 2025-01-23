# Etapa de construção com SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar o arquivo .csproj para o contêiner e restaurar dependências
COPY FilmesAPI/FilmesAPI.csproj ./FilmesAPI/
RUN dotnet restore ./FilmesAPI/FilmesAPI.csproj

# Copiar o restante dos arquivos do código
COPY . .

# Compilar o código
WORKDIR /src/FilmesAPI
RUN dotnet build FilmesAPI.csproj -c Release -o /app/build

# Etapa de publicação
FROM build AS publish
RUN dotnet publish FilmesAPI.csproj -c Release -o /app/publish

# Etapa de execução com a imagem de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
# EXPOSE 80
WORKDIR /app

# Copiar os arquivos publicados
COPY --from=publish /app/publish .

# Executar a aplicação
ENTRYPOINT ["dotnet", "FilmesAPI.dll"]
EXPOSE 80
