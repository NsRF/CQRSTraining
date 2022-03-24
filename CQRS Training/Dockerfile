FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CQRS Training/CQRS Training.csproj", "CQRS Training/"]
RUN dotnet restore "CQRS Training/CQRS Training.csproj"
COPY . .
WORKDIR "/src/CQRS Training"
RUN dotnet build "CQRS Training.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CQRS Training.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CQRS Training.dll"]
