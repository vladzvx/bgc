


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["BGC.WebApi/BGC.WebApi.csproj", "BGC.WebApi/"]
COPY ["BGC.Server/BGC.Server.csproj", "BGC.Server/"]
COPY ["BGC.Common/BGC.Common.csproj", "BGC.Common/"]
RUN dotnet restore "./BGC.WebApi/BGC.WebApi.csproj"
COPY . .
WORKDIR "/src/BGC.WebApi"
RUN dotnet build "./BGC.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BGC.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BGC.WebApi.dll"]