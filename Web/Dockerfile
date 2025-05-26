# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8085
EXPOSE 8086
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_USE_POLLING_FILE_WATCHER=true

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
RUN dotnet dev-certs https --clean
RUN dotnet dev-certs https --trust
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY ["Web/Web.csproj", "Web/"]
COPY ["LearningSupportSystem.ServiceDefaults/LearningSupportSystem.ServiceDefaults.csproj", "LearningSupportSystem.ServiceDefaults/"]
COPY ["Quiz/QuizApp.csproj", "Quiz/"]
RUN dotnet restore "./Web/Web.csproj"
COPY . .
WORKDIR "/src/Web"
RUN dotnet build "./Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.dll"]