#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 8888

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Ams.Admin.WebApi/Ams.Admin.WebApi.csproj", "Ams.Admin.WebApi/"]
COPY ["Ams.CodeGenerator/Ams.CodeGenerator.csproj", "Ams.CodeGenerator/"]
COPY ["Infrastructure/Ams.Infrastructure.csproj", "Infrastructure/"]
COPY ["Ams.Common/Ams.Common.csproj", "Ams.Common/"]
COPY ["Ams.Service/Ams.Service.csproj", "Ams.Service/"]
COPY ["Ams.Repository/Ams.Repository.csproj", "Ams.Repository/"]
COPY ["Ams.Model/Ams.Model.csproj", "Ams.Model/"]
COPY ["Ams.Service/Ams.Service.csproj", "Ams.Service/"]
COPY ["Ams.Tasks/Ams.Tasks.csproj", "Ams.Tasks/"]
RUN dotnet restore "./Ams.Admin.WebApi/Ams.Admin.WebApi.csproj"
COPY . .
WORKDIR "/src/Ams.Admin.WebApi"
RUN dotnet build "./Ams.Admin.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Ams.Admin.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ams.Admin.WebApi.dll"]