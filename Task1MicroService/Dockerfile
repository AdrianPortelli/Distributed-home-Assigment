FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

COPY MicroServiceThree/MicroServiceThree.csproj MicroServiceThree/
RUN dotnet restore MicroServiceThree/MicroServiceThree.csproj

COPY . ./
RUN dotnet publish MicroServiceThree/MicroServiceThree.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "MicroServiceThree.dll"]