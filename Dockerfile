# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .
RUN dotnet restore "src/Wee.SapIntegration.API/Wee.SapIntegration.API.csproj"
RUN dotnet publish "src/Wee.SapIntegration.API/Wee.SapIntegration.API.csproj" -c Release -o /app/publish

# Etapa 2: runtime con ICU
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Asegurar ICU
RUN apt-get update && apt-get install -y --no-install-recommends libicu72 \
    && rm -rf /var/lib/apt/lists/*

COPY --from=build /app/publish .

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

EXPOSE 80
ENTRYPOINT ["dotnet", "Wee.SapIntegration.API.dll"]