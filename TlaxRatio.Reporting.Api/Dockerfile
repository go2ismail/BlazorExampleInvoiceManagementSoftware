#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TlaxRatio.Reporting.Api/TlaxRatio.Reporting.Api.csproj", "TlaxRatio.Reporting.Api/"]
RUN dotnet restore "TlaxRatio.Reporting.Api/TlaxRatio.Reporting.Api.csproj"
COPY . .
WORKDIR "/src/TlaxRatio.Reporting.Api"
RUN dotnet build "TlaxRatio.Reporting.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TlaxRatio.Reporting.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TlaxRatio.Reporting.Api.dll"]