# Use the official .NET SDK image to build and publish the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy solution and project files, including test projects
COPY *.sln .
COPY Fruityvice/*.csproj ./Fruityvice/
COPY Fruityvice.Tests/*.csproj ./Fruityvice.Tests/
COPY Fruityvice.Tests.Integration/*.csproj ./Fruityvice.Tests.Integration/

# Restore dependencies
RUN dotnet restore

# Copy the entire source code and publish the application
COPY . .
RUN dotnet publish -c Release -o out

# Use the runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "Fruityvice.dll"]
