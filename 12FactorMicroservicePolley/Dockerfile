#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["12FactorMicroservicePolley/12FactorMicroservicePolley.csproj", "12FactorMicroservicePolley/"]
RUN dotnet restore "12FactorMicroservicePolley/12FactorMicroservicePolley.csproj"
COPY . .
WORKDIR "/src/12FactorMicroservicePolley"
RUN dotnet build "12FactorMicroservicePolley.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "12FactorMicroservicePolley.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "12FactorMicroservicePolley.dll"]