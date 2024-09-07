FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5093

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY ./Core/ ./Core/
COPY ./Infrastructure/ ./Infrastructure/
COPY ./API/ ./API/
RUN dotnet restore "./API/API/API.csproj"
WORKDIR "/src/API/API"
RUN dotnet build API.csproj -c $BUILD_CONFIGURATION -o /build

FROM build AS publish
ARG BUILD_CONFIGURATION=Debug
WORKDIR "/src/API/API"
RUN dotnet publish API.csproj -c $BUILD_CONFIGURATION -o /publish /p:UseAppHost

FROM base AS final
WORKDIR /app
COPY --from=publish /publish .
ENTRYPOINT ["dotnet", "Numployable.API.dll"]


