# Usando a imagem do SDK do .NET
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Definir o diret�rio de trabalho para o build
WORKDIR /src

# Copiar o arquivo .csproj do frontend para o cont�iner
COPY Frontend/Frontend.csproj ./Frontend/

# Restaurar as depend�ncias
RUN dotnet restore ./Frontend/Frontend.csproj

# Copiar todos os arquivos restantes do projeto para o cont�iner
COPY Frontend/. ./Frontend/

# Compilar e publicar a aplica��o
RUN dotnet publish ./Frontend/Frontend.csproj -c Release -o /app

# Usar a imagem de runtime para a execu��o
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

# Definir o diret�rio de trabalho para o cont�iner final
WORKDIR /app

# Expor a porta para acesso
EXPOSE 8080

# Copiar os arquivos do est�gio de build
COPY --from=build /app .

# Rodar a aplica��o Razor
ENTRYPOINT ["dotnet", "Frontend.dll"]
