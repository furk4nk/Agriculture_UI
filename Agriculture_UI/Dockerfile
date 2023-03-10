#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Agriculture_UI/Agriculture_UI.csproj", "Agriculture_UI/"]
COPY ["BusinessLayer/BusinessLayer.csproj", "BusinessLayer/"]
COPY ["DataAccessLayer/DataAccessLayer.csproj", "DataAccessLayer/"]
COPY ["EntityLayer/EntityLayer.csproj", "EntityLayer/"]
RUN dotnet restore "Agriculture_UI/Agriculture_UI.csproj"
COPY . .
WORKDIR "/src/Agriculture_UI"
RUN dotnet build "Agriculture_UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Agriculture_UI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Agriculture_UI.dll"]