FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Копируем csproj файл
COPY MedicalCardsWeb.csproj .

# Восстанавливаем пакеты
RUN dotnet restore

# Копируем все остальные файлы
COPY . .

# Публикуем
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "MedicalCardsWeb.dll"]