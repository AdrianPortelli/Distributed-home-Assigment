FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

COPY MicroServiceTwo/MicroServiceTwo.csproj MicroServiceTwo/
RUN dotnet restore MicroServiceTwo/MicroServiceTwo.csproj

COPY . ./
RUN dotnet publish MicroServiceTwo/MicroServiceTwo.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "MicroServiceTwo.dll"]