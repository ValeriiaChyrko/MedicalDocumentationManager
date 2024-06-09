FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MedicalDocumentationManager.Persistence/MedicalDocumentationManager.Persistence.csproj", "MedicalDocumentationManager.Persistence/"]
RUN dotnet restore "MedicalDocumentationManager.Persistence/MedicalDocumentationManager.Persistence.csproj"
COPY . .
WORKDIR "/src/MedicalDocumentationManager.Persistence"
RUN dotnet build "MedicalDocumentationManager.Persistence.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MedicalDocumentationManager.Persistence.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MedicalDocumentationManager.Persistence.dll"]
