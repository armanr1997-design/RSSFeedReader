# Quickstart: Run the MVP locally

These instructions assume the repository uses the `backend/` and `frontend/` layout described in the plan. Adjust project paths as needed.

1. Install .NET SDK (recommended: .NET 10)

2. Start the backend API (powershell):

```powershell
dotnet run --project backend/RSSFeedReader.Api/RSSFeedReader.Api.csproj
```

3. Start the Blazor frontend (powershell):

```powershell
dotnet run --project frontend/RSSFeedReader.UI/RSSFeedReader.UI.csproj
```

4. Open the frontend URL in a browser (default shown in terminal). Add subscriptions via the UI and verify they appear in the list.

5. Verify add-to-list feedback is visible within 1 second after submitting a valid URL.

Notes:
- Ensure backend and frontend ports are coordinated (see `TechStack.md`).
- Backend must enable CORS for the frontend origin during local development.
