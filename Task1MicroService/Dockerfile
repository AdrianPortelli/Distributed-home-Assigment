FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env
WORKDIR /app

COPY DigitalWalletWebApp/DigitalWalletWebApp.csproj DigitalWalletWebApp/
RUN dotnet restore DigitalWalletWebApp/DigitalWalletWebApp.csproj

COPY . ./
RUN dotnet publish DigitalWalletWebApp/DigitalWalletWebApp.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "DigitalWalletWebApp.dll"]