# TeamPulse

TeamPulse — это проект для управления перекличкой работников, учёта их заработка за день, а также категоризации выполняемых задач. Проект построен с использованием современных технологий и архитектурных подходов для обеспечения масштабируемости, удобства поддержки и высококачественного пользовательского опыта.

## Используемые технологии

### Backend

- .NET 8: Основной фреймворк для разработки серверной части.
- Entity Framework Core 8: ORM для работы с базой данных.
- Clean Architecture: Архитектурный подход для упрощения поддержки и тестирования.
- Generic Repository Pattern: Универсальный репозиторий для работы с сущностями.
- Result Pattern: Для управления результатами выполнения операций.
- API Conventions: Конвенции для стандартизации работы API.
- DTO: Data Transfer Objects для передачи данных между клиентом и сервером.
- Filters: Для фильтрации данных API-запросов.
- Pagination: Реализация пагинации для работы с большими наборами данных.
- API Response & Pagination Response: Унифицированные ответы от API.

### Frontend

- Blazor WebAssembly (WASM): Современный подход к разработке фронтенда с использованием C#.
- Монолитная архитектура: Упрощённое управление и развертывание фронтенд-части.

## Архитектура проекта

### Client-Server

Проект построен на архитектуре "клиент-сервер", где:

- Frontend (Blazor WASM) обрабатывает взаимодействие с пользователем.
- Backend (ASP.NET Core API) предоставляет данные и управляет логикой приложения.

### Backend

Реализована Clean Architecture для разделения логики на слои:

1. Core:
    - Содержит бизнес-логику и интерфейсы.
    - DTO, Result, Filters.
2. Infrastructure:
    - Работа с базой данных через EF Core.
    - Реализация паттерна "Generic Repository".
3. API:
    - Контроллеры, обработка запросов и отправка ответов.
    - API Conventions и стандартизация ответов.

### Frontend

Blazor WebAssembly используется для создания интуитивно понятного интерфейса:

- Одностраничное приложение (SPA).
- Подключение к API через HTTP.
- Реализация компонентов для работы с таблицами, фильтрацией и пагинацией.

## Основные таблицы

1. Employee:
    - Хранение данных о сотрудниках (например, имя, должность, ставка).
2. Journal:
    - Записи о рабочем времени сотрудников, их заработке за день.
3. Category:
    - Категории задач или типов работ.

## Возможности проекта

- Управление сотрудниками: добавление, редактирование и удаление.
- Перекличка сотрудников: отслеживание присутствия на рабочем месте.
- Учёт заработка сотрудников за день.
- Фильтрация и пагинация данных в журналах.
- Просмотр категорий задач.
- Генерация унифицированных API-ответов с учётом пагинации и фильтров.
