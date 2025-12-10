# Этап 1: Сборка
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src/Quiz/

# 1. Копируем файл проекта из корня контекста (Quiz.csproj)
COPY ["Quiz.csproj", "."] 

# 2. Восстанавливаем зависимости
RUN dotnet restore

# 3. Копируем весь остальной код из корня контекста
COPY . .

# 4. Публикуем приложение в режиме Release
RUN dotnet publish -c Release -o /app/publish

# Этап 2: Запуск (Уменьшенный размер)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "Quiz.dll"]