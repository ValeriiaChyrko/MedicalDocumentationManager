FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MedicalDocumentationManager/MedicalDocumentationManager.csproj", "MedicalDocumentationManager/"]
RUN dotnet restore "MedicalDocumentationManager/MedicalDocumentationManager.csproj"
COPY . .
WORKDIR "/src/MedicalDocumentationManager"
RUN dotnet build "MedicalDocumentationManager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MedicalDocumentationManager.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MedicalDocumentationManager.dll"]
