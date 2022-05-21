FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

COPY MicroServiceSix/MicroServiceSix.csproj MicroServiceSix/
RUN dotnet restore MicroServiceSix/MicroServiceSix.csproj

COPY . ./
RUN dotnet publish MicroServiceSix/MicroServiceSix.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "MicroServiceSix.dll"]