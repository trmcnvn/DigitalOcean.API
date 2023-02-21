FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DigitalOcean.Shared.WebApplicationExtensions/DigitalOcean.Shared.WebApplicationExtensions.csproj", "DigitalOcean.Shared.WebApplicationExtensions/"]
RUN dotnet restore "DigitalOcean.Shared.WebApplicationExtensions/DigitalOcean.Shared.WebApplicationExtensions.csproj"
COPY . .
WORKDIR "/src/DigitalOcean.Shared.WebApplicationExtensions"
RUN dotnet build "DigitalOcean.Shared.WebApplicationExtensions.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DigitalOcean.Shared.WebApplicationExtensions.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DigitalOcean.Shared.WebApplicationExtensions.dll"]
