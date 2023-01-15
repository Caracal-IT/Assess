FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Caracal.Assess.Api/Caracal.Assess.Api.csproj", "src/Caracal.Assess.Api/"]
RUN dotnet restore "src/Caracal.Assess.Api/Caracal.Assess.Api.csproj"
COPY . .
WORKDIR "/src/src/Caracal.Assess.Api"
RUN dotnet build "Caracal.Assess.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Caracal.Assess.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Caracal.Assess.Api.dll"]
