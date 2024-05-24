FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

EXPOSE 8000

# copy csproj and restore as distinct layers
COPY LibraryCataloger/*.csproj LibraryCataloger/
COPY LibraryCataloger.Data/*.csproj LibraryCataloger.Data/
COPY LibraryCatalogerTests/*.csproj LibraryCatalogerTests/
RUN dotnet restore LibraryCataloger/LibraryCataloger.csproj

  

# # copy and build app and libraries
COPY LibraryCataloger/ LibraryCataloger/
COPY LibraryCataloger.Data/ LibraryCataloger.Data/
COPY LibraryCatalogerTests/ LibraryCatalogerTests/

# test stage -- exposes optional entrypoint
# target entrypoint with: docker build --target test
FROM build AS test
WORKDIR /source/LibraryCatalogerTests
RUN dotnet restore
RUN dotnet build --no-restore

ENTRYPOINT ["dotnet", "test", "--logger:trx", "--no-build"]

FROM build AS publish
WORKDIR /source/LibraryCataloger
RUN dotnet publish -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LibraryCataloger.dll"]