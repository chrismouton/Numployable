FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER app
WORKDIR /web
EXPOSE 5055

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY ./API/ ./API/
COPY ./UI/ ./UI/
RUN dotnet restore "./UI/Web/Web.csproj"
WORKDIR "/src/UI/Web"
RUN dotnet build Web.csproj -c $BUILD_CONFIGURATION -o /build

FROM build AS publish
ARG BUILD_CONFIGURATION=Debug
WORKDIR "/src/UI/Web"
RUN dotnet publish Web.csproj -c $BUILD_CONFIGURATION -o /publish /p:UseAppHost

FROM base AS final
WORKDIR /web
COPY --from=publish /publish .
ENTRYPOINT ["dotnet", "Numployable.UI.Web.dll"]


