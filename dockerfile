# Use a imagem oficial do .NET como uma imagem de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copie os arquivos de projeto e restaure as dependências
COPY *.csproj ./
RUN dotnet restore

# Copie todos os arquivos do projeto e construa a aplicação
COPY . ./
RUN dotnet publish -c Release -o /app/out

# Use uma imagem runtime do .NET para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Exponha a porta que a aplicação vai rodar
EXPOSE 80

# Comando para rodar a aplicação
ENTRYPOINT ["dotnet", "teste.dll"]
