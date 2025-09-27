# --- Stage 1: build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ContaBancaria.csproj ./
RUN dotnet restore ContaBancaria.csproj

COPY . .
RUN dotnet publish ContaBancaria.csproj -c Release -o /app --no-restore

# --- Stage 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app ./

ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

ENTRYPOINT ["dotnet", "ContaBancaria.dll"]


