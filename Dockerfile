# Stage 1: Build the application using the SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copy the solution file and restore dependencies
COPY LeaveManagmentSystem.sln .
COPY LeaveManagementSystem.Application/*.csproj ./LeaveManagementSystem.Application/
COPY LeaveManagementSystem.Common/*.csproj ./LeaveManagementSystem.Common/
COPY LeaveManagmentSystem.Data/*.csproj ./LeaveManagmentSystem.Data/
COPY LeaveManagmentSystem.Web/*.csproj ./LeaveManagmentSystem.Web/
RUN dotnet restore

# Copy the entire project structure and build the project
COPY . .
WORKDIR /source/LeaveManagmentSystem.Web
RUN dotnet publish -c release -o /app

# Stage 2: Run the app in a runtime-only image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "LeaveManagmentSystem.Web.dll"]
