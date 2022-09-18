#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Setups.API/Setups.API.csproj", "src/Setups.API/"]
COPY ["src/CommonBase.Data/CommonBase.Data.csproj", "src/CommonBase.Data/"]
RUN dotnet restore "src/Setups.API/Setups.API.csproj"
COPY . .
WORKDIR "/src/src/Setups.API"
RUN dotnet build "Setups.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Setups.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Setups.API.dll"]