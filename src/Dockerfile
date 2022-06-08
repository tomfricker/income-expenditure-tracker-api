#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Income.Expenditure.Tracker.Api/Income.Expenditure.Tracker.Api.csproj", "Income.Expenditure.Tracker.Api/"]
RUN dotnet restore "Income.Expenditure.Tracker.Api/Income.Expenditure.Tracker.Api.csproj"
COPY . .
WORKDIR "/src/Income.Expenditure.Tracker.Api"
RUN dotnet build "Income.Expenditure.Tracker.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Income.Expenditure.Tracker.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Income.Expenditure.Tracker.Api.dll"]