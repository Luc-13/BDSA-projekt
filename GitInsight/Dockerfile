FROM mcr.microsoft.com/dotnet/runtime:6.0-alpine AS base
WORKDIR /app

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["GitInsight/GitInsight.csproj", "GitInsight/"]
RUN dotnet restore "GitInsight/GitInsight.csproj"
COPY . .
WORKDIR "/src/GitInsight"
RUN dotnet build "GitInsight.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GitInsight.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GitInsight.dll"]
