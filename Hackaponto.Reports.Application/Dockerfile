#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Hackaponto.Reports/Hackaponto.Reports.csproj", "Hackaponto.Reports/"]
RUN dotnet restore "./Hackaponto.Reports/Hackaponto.Reports.csproj"
COPY . .
WORKDIR "/src/Hackaponto.Reports"
RUN dotnet build "./Hackaponto.Reports.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Hackaponto.Reports.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
RUN apk update && apk add tzdata &&\ 
    cp /usr/share/zoneinfo/America/Sao_Paulo /etc/localtime &&\ 
    echo "America/Sao_Paulo" > /etc/timezone &&\ 
    apk del tzdata && rm -rf /var/cache/apk/*
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hackaponto.Reports.dll"]
