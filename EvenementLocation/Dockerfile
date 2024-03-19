#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./Ludotheque.EvenementLocation.csproj", "Ludotheque.EvenementLocation/"]
RUN dotnet restore "Ludotheque.EvenementLocation/Ludotheque.EvenementLocation.csproj"
COPY . .
WORKDIR "/src/Ludotheque.EvenementLocation"
RUN dotnet build "Ludotheque.EvenementLocation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ludotheque.EvenementLocation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ludotheque.EvenementLocation.dll"]