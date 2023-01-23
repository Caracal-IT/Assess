FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Caracal.Assess.Mvc/Caracal.Assess.Mvc.csproj", "src/Caracal.Assess.Mvc/"]
RUN dotnet restore "src/Caracal.Assess.Mvc/Caracal.Assess.Mvc.csproj"
COPY . .
WORKDIR "/src/src/Caracal.Assess.Mvc"
RUN dotnet build "Caracal.Assess.Mvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Caracal.Assess.Mvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY src/Caracal.Assess.Mvc/certs/dockerdemo.pfx ./https/dockerdemo.pfx
ENTRYPOINT ["dotnet", "Caracal.Assess.Mvc.dll"]
