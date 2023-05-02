FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Emergency_Medical_Service/Emergency_Medical_Service.csproj", "Emergency_Medical_Service/"]
RUN dotnet restore "Emergency_Medical_Service/Emergency_Medical_Service.csproj"
COPY . .
WORKDIR "/src/Emergency_Medical_Service"
RUN dotnet build "Emergency_Medical_Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Emergency_Medical_Service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Emergency_Medical_Service.dll"]
