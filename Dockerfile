FROM registryll.azurecr.io/dotnet/core/aspnet:latest AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["TCC.Backend.Api/TCC.Backend.Api.csproj", "TCC.Backend.Api/"]
COPY ["TCC.Backend.CrossCutting/TCC.Backend.CrossCutting.csproj", "TCC.Backend.CrossCutting/"]
COPY ["TCC.Backend.Domain/TCC.Backend.Domain.csproj", "TCC.Backend.Domain/"]
COPY ["TCC.Backend.Domain.Core/TCC.Backend.Domain.Core.csproj", "TCC.Backend.Domain.Core/"]
COPY ["TCC.Backend.Infrastructure/TCC.Backend.Infrastructure.csproj", "TCC.Backend.Infrastructure/"]
COPY ["TCC.Backend.Application/TCC.Backend.Application.csproj", "TCC.Backend.Application/"]
COPY . .
WORKDIR /src/TCC.Backend.Api
RUN dotnet publish TCC.Backend.Api.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "TCC.Backend.Api.dll"]