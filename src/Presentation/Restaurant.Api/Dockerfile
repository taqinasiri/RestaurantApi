# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Presentation/Restaurant.Api/Restaurant.Api.csproj", "src/Presentation/Restaurant.Api/"]
COPY ["src/Infrastructure/Restaurant.Infrastructure/Restaurant.Infrastructure.csproj", "src/Infrastructure/Restaurant.Infrastructure/"]
COPY ["src/Core/Restaurant.Application/Restaurant.Application.csproj", "src/Core/Restaurant.Application/"]
COPY ["src/Core/Restaurant.Domain/Restaurant.Domain.csproj", "src/Core/Restaurant.Domain/"]
COPY ["src/Infrastructure/Restaurant.Persistence/Restaurant.Persistence.csproj", "src/Infrastructure/Restaurant.Persistence/"]
RUN dotnet restore "./src/Presentation/Restaurant.Api/Restaurant.Api.csproj"
COPY . .
WORKDIR "/src/src/Presentation/Restaurant.Api"
RUN dotnet build "./Restaurant.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Restaurant.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Restaurant.Api.dll"]