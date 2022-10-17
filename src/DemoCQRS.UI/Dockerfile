#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DemoCQRS.UI/DemoCQRS.UI.csproj", "DemoCQRS.UI/"]
COPY ["src/DemoCQRS.Read/DemoCQRS.Read.csproj", "src/DemoCQRS.Read/"]
COPY ["src/DemoCQRS.Application/DemoCQRS.Application.csproj", "src/DemoCQRS.Application/"]
COPY ["src/DemoCQRS.Domain/DemoCQRS.Domain.csproj", "src/DemoCQRS.Domain/"]
COPY ["src/DemoCQRS.Persistence/DemoCQRS.Write.csproj", "src/DemoCQRS.Persistence/"]
RUN dotnet restore "DemoCQRS.UI/DemoCQRS.UI.csproj"
COPY . .
WORKDIR "/src/DemoCQRS.UI"
RUN dotnet build "DemoCQRS.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DemoCQRS.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoCQRS.UI.dll"]