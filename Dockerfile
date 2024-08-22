FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SkateShop.Api/SkateShop.Api.csproj", "SkateShop.Api/"]
COPY ["SkateShop.Application/SkateShop.Application.csproj", "SkateShop.Application/"]
COPY ["SkateShop.Infrastructure/SkateShop.Infrastructure.csproj", "SkateShop.Infrastructure/"]
COPY ["SkateShop.Domain/SkateShop.Domain.csproj", "SkateShop.Domain/"]
RUN dotnet restore "SkateShop.Api/SkateShop.Api.csproj"
COPY . .
WORKDIR "/src/SkateShop.Api"
RUN dotnet build "SkateShop.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SkateShop.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SkateShop.Api.dll"]