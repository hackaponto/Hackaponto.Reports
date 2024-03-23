#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Hackaponto.Reports.Application/Hackaponto.Reports.Application.csproj", "Hackaponto.Reports.Application/"]
COPY ["Hackaponto.Reports.Domain/Hackaponto.Reports.Entities.csproj", "Hackaponto.Reports.Domain/"]
COPY ["Hackaponto.Reports.Repository/Hackaponto.Reports.Infrastructure.csproj", "Hackaponto.Reports.Repository/"]
COPY ["Hackaponto.Reports.UseCases/Hackaponto.Reports.UseCases.csproj", "Hackaponto.Reports.UseCases/"]
RUN dotnet restore "./Hackaponto.Reports.Application/Hackaponto.Reports.Application.csproj"
COPY . .
WORKDIR "/src/Hackaponto.Reports.Application"
RUN dotnet build "./Hackaponto.Reports.Application.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Hackaponto.Reports.Application.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hackaponto.Reports.Application.dll"]