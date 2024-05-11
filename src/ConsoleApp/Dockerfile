FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

RUN dotnet tool install --global dotnet-dump --version 8.0.510501

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App

RUN apt-get update && apt-get install -y procps && rm -rf /var/lib/apt/lists/*

ENV PATH="${PATH}:/root/.dotnet/tools"
COPY --from=build-env /root/.dotnet/tools /root/.dotnet/tools


COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "ConsoleApp.dll"]