# Etapa de construção com SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar o arquivo .csproj para o contêiner e restaurar dependências
COPY Backend/Backend.csproj ./Backend/
RUN dotnet restore ./Backend/Backend.csproj

# Copiar o restante dos arquivos do código
COPY . .

# Compilar o código
WORKDIR /src/Backend
RUN dotnet build Backend.csproj -c Release -o /app/build

# Etapa de publicação
FROM build AS publish
RUN dotnet publish Backend.csproj -c Release -o /app/publish

# Etapa de execução com a imagem de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
# EXPOSE 80
WORKDIR /app

# Copiar os arquivos publicados
COPY --from=publish /app/publish .

# Executar a aplicação
ENTRYPOINT ["dotnet", "Backend.dll"]
EXPOSE 8080
