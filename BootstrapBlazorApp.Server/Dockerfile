FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY BootstrapBlazorApp.Shared/BootstrapBlazorApp.Shared.csproj BootstrapBlazorApp.Shared/
COPY BootstrapBlazorApp.Server/BootstrapBlazorApp.Server.csproj BootstrapBlazorApp.Server/
RUN dotnet restore BootstrapBlazorApp.Server/BootstrapBlazorApp.Server.csproj

# copy everything and build
COPY . .

WORKDIR /app/BootstrapBlazorApp.Server
RUN dotnet publish -c Release -o out

# build runtime image
FROM base AS final
WORKDIR /app
COPY --from=build-env /app/BootstrapBlazorApp.Server/out .
ENTRYPOINT ["dotnet", "BootstrapBlazorApp.Server.dll"]