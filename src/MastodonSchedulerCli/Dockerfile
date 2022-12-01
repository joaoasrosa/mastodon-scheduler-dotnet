FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MastodonSchedulerCli/MastodonSchedulerCli.csproj", "MastodonSchedulerCli/"]
RUN dotnet restore "MastodonSchedulerCli/MastodonSchedulerCli.csproj"
COPY . .
WORKDIR "/src/MastodonSchedulerCli"
RUN dotnet build "MastodonSchedulerCli.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MastodonSchedulerCli.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MastodonSchedulerCli.dll"]
