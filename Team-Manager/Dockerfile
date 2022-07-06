#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
RUN dotnet restore "Team-Manager.csproj"
COPY . .
RUN dotnet build "Team-Manager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Team-Manager.csproj" -c Release -o /app/publish

FROM base AS final
RUN ["apt-get", "update"]
RUN ["apt-get", "-y", "install", "libgdiplus"]
RUN ["apt-get", "-y", "install", "xvfb", "libfontconfig", "wkhtmltopdf"]
RUN ["apt-get", "-y", "install", "libc6-dev"]
RUN ["apt-get", "-y", "install", "openssl"]
RUN ["apt-get", "-y", "install", "libssl1.1"]
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=publish /src/libwkhtmltox.dll libwkhtmltox.dll
COPY --from=publish /src/libwkhtmltox.so libwkhtmltox.so
COPY --from=publish /src/libwkhtmltox.dylib libwkhtmltox.dylib

CMD ASPNETCORE_URLS=http://*:$PORT dotnet Team-Manager.dll
