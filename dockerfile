# Default information from docker on building dotenetcore apps
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build-env
WORKDIR /app

# copy csproj and restore as destinct layers
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build
COPY . ./

EXPOSE 80

RUN dotnet publish -c Release -o out 

# build runtime
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "MovieQueueBackend.dll"]
