#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 8888

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Ams.WebApi/Ams.WebApi.csproj", "Ams.WebApi/"]
COPY ["Ams.CodeGenerator/Ams.CodeGenerator.csproj", "Ams.CodeGenerator/"]
COPY ["Ams.Infrastructure/Ams.Infrastructure.csproj", "Ams.Infrastructure/"]
COPY ["Ams.Common/Ams.Common.csproj", "Ams.Common/"]
COPY ["Ams.Service/Ams.Service.csproj", "Ams.Service/"]
COPY ["Ams.Repository/Ams.Repository.csproj", "Ams.Repository/"]
COPY ["Ams.Model/Ams.Model.csproj", "Ams.Model/"]
COPY ["Ams.Tasks/Ams.Tasks.csproj", "Ams.Tasks/"]
RUN dotnet restore "./Ams.WebApi/Ams.WebApi.csproj"
COPY . .
WORKDIR "/src/Ams.WebApi"
RUN dotnet build "./Ams.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Ams.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ams.WebApi.dll"]