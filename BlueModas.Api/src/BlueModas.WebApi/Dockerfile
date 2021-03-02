#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/BlueModas.WebApi/BlueModas.WebApi.csproj", "src/BlueModas.WebApi/"]
RUN dotnet restore "src/BlueModas.WebApi/BlueModas.WebApi.csproj"
COPY . .
WORKDIR "/src/src/BlueModas.WebApi"
RUN dotnet build "BlueModas.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlueModas.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlueModas.WebApi.dll"]