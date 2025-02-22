# Usa la imagen base de .NET SDK para compilar y publicar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia los archivos del proyecto
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Usa la imagen runtime para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Exponer el puerto
EXPOSE 80
EXPOSE 443

# Ejecutar la app
ENTRYPOINT ["dotnet", "Aplicacion.Acme.WebApi.dll"]
