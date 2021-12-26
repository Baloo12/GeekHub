FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GeekHub.BoardGames.BggProvider.Web/GeekHub.BoardGames.BggProvider.Web.csproj", "GeekHub.BoardGames.BggProvider.Web/"]
RUN dotnet restore "GeekHub.BoardGames.BggProvider.Web/GeekHub.BoardGames.BggProvider.Web.csproj"
COPY . .
WORKDIR "/src/GeekHub.BoardGames.BggProvider.Web"
RUN dotnet build "GeekHub.BoardGames.BggProvider.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GeekHub.BoardGames.BggProvider.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GeekHub.BoardGames.BggProvider.Web.dll"]
