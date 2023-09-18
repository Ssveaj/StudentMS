#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["StudentService/StudentService.csproj", "StudentService/"]
COPY ["Core/Core.csproj", "Core/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "StudentService/StudentService.csproj"
COPY . .
WORKDIR "/src/StudentService"
RUN dotnet build "StudentService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudentService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentService.dll"]