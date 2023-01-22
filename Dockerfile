# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY ./graph/graphql-api.csproj .
RUN dotnet restore

# copy everything else and build app
COPY ./graph/graphql .
COPY ./graph/models .
COPY ./graph/Properties .
COPY ./graph/appsettings.json .
COPY ./graph/Program.cs .
WORKDIR /source/
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./

ENTRYPOINT ["dotnet", "graphql-api.dll"]