FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copier csproj et restaurer les dépendances
COPY ["Ticketing System.csproj", "."]
RUN dotnet restore "./Ticketing System.csproj"

# Copier le reste du code source
COPY . .
WORKDIR "/src/."
RUN dotnet build "Ticketing System.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ticketing System.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Créer le répertoire pour les pièces jointes
RUN mkdir -p /app/wwwroot/Attachments && \
    chmod -R 777 /app/wwwroot/Attachments

# Forcer l'utilisation de HTTP uniquement dans Docker
ENV ASPNETCORE_URLS=http://+:80

# Point d'entrée
ENTRYPOINT ["dotnet", "Ticketing System.dll"]