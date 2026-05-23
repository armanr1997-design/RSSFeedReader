# RSSFeedReader

A minimal RSS subscription manager MVP implemented as an ASP.NET Core Web API backend and a Blazor WebAssembly frontend.

## Requirements

- .NET SDK 10

## Quickstart

1. Start the backend API:

```powershell
cd c:\TrainingProjects\RSSFeedReader
dotnet run --project backend/RSSFeedReader.Api/RSSFeedReader.Api.csproj
```

2. Start the frontend app:

```powershell
cd c:\TrainingProjects\RSSFeedReader

dotnet run --project frontend/RSSFeedReader.UI/RSSFeedReader.UI.csproj
```

3. Open the browser at the URL shown for the frontend and add subscriptions.

## Projects

- `backend/RSSFeedReader.Api` — ASP.NET Core Web API
- `frontend/RSSFeedReader.UI` — Blazor WebAssembly frontend
- `tests/backend.unit` — backend xUnit tests
- `tests/frontend.components` — frontend bUnit component tests

## Notes

- The backend listens on `http://localhost:5170` by default and exposes `POST /api/subscriptions` and `GET /api/subscriptions`.
- The frontend is configured to use `http://localhost:5170/api/` via `frontend/RSSFeedReader.UI/wwwroot/appsettings.json`.
