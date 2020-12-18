#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Bost.Agent.Service/Bost.Agent.Service.csproj", "Bost.Agent.Service/"]
RUN dotnet restore "Bost.Agent.Service/Bost.Agent.Service.csproj"
COPY . .
WORKDIR "/src/Bost.Agent.Service"
RUN dotnet build "Bost.Agent.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bost.Agent.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bost.Agent.Service.dll"]