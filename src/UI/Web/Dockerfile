FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /web
EXPOSE 5055

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY ["./Core/Application/Application.csproj", "Core/Application/"]
COPY ["./Core/Common/Common.csproj", "Core/Common/"]
COPY ["./Core/Domain/Domain.csproj", "Core/Domain/"]
COPY ["./Infrastructure/Infrastructure/Infrastructure.csproj", "/Infrastructure/Infrastructure/"]
COPY ["./Infrastructure/Persistence/Persistence.csproj", "/Infrastructure/Infrastructure/"]
COPY ["./UI/Web/Web.csproj", "UI/Web/"]
RUN dotnet restore "./UI/Web/Web.csproj"
COPY ./Core/ ./Core/
COPY ./Infrastructure/ ./Infrastructure/
COPY ./UI/ ./UI/
WORKDIR "/src/UI/Web"
RUN dotnet build Web.csproj -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Debug
WORKDIR "/src/UI/Web"
RUN dotnet publish Web.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Numployable.UI.Web.dll"]


