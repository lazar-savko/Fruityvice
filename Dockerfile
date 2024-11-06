# Use the official .NET SDK image to build and publish the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY Fruityvice/*.csproj ./Fruityvice/
RUN dotnet restore

# Copy the rest of the application files and build the app
COPY . .
RUN dotnet publish -c Release -o out

# Use the runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "Fruityvice.dll"]
