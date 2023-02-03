FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["todo-list-api.csproj", "todo-list-api/"]
RUN dotnet restore "./todo-list-api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "todo-list-api.proj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "todo-list-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "todo-list-api.dll"]