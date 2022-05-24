FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

COPY MicroServiceSeven/MicroServiceSeven.csproj MicroServiceSeven/
RUN dotnet restore MicroServiceSeven/MicroServiceSeven.csproj

COPY . ./
RUN dotnet publish MicroServiceSeven/MicroServiceSeven.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "MicroServiceSeven.dll"]