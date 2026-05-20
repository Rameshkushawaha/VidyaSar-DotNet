# ── Stage 1: Build ──────────────────────────────
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and all project files first (for layer caching)
COPY VidyaSar.sln .
COPY src/VidyaSar.API/VidyaSar.API.csproj               src/VidyaSar.API/
COPY src/VidyaSar.Application/VidyaSar.Application.csproj src/VidyaSar.Application/
COPY src/VidyaSar.Domain/VidyaSar.Domain.csproj           src/VidyaSar.Domain/
COPY src/VidyaSar.Infrastructure/VidyaSar.Infrastructure.csproj src/VidyaSar.Infrastructure/

# Restore packages
RUN dotnet restore

# Copy everything else
COPY . .

# Build and publish
RUN dotnet publish src/VidyaSar.API/VidyaSar.API.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

# ── Stage 2: Runtime ─────────────────────────────
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy published output from build stage
COPY --from=build /app/publish .

# Render uses port 8080
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "VidyaSar.API.dll"]