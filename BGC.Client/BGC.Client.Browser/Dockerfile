FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

RUN dotnet workload install wasm-tools
RUN apt-get update
RUN apt-get install -y python3

COPY . .

RUN dotnet restore "./BGC.Client/BGC.Client.Browser/BGC.Client.Browser.csproj"

WORKDIR "/src/BGC.Client/BGC.Client.Browser"

RUN dotnet build "./BGC.Client.Browser.csproj" -c Release -o /app/build

FROM nginx
COPY --from=build /app/build/AppBundle /usr/share/nginx/html/