FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5093

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY ["./Core/Application/Application.csproj", "Core/Application/"]
COPY ["./Core/Common/Common.csproj", "Core/Common/"]
COPY ["./Core/Domain/Domain.csproj", "Core/Domain/"]
COPY ["./Infrastructure/Infrastructure/Infrastructure.csproj", "/Infrastructure/Infrastructure/"]
COPY ["./Infrastructure/Persistence/Persistence.csproj", "/Infrastructure/Infrastructure/"]
COPY ["./API/API/API.csproj", "API/API/"]
RUN dotnet restore "./API/API/API.csproj"
COPY ./Core/ ./Core/
COPY ./Infrastructure/ ./Infrastructure/
COPY ./API/ ./API/
WORKDIR "/src/API/API"
RUN dotnet build API.csproj -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Debug
WORKDIR "/src/API/API"
RUN dotnet publish API.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Numployable.API.dll"]


