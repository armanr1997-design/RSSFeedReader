# API Contract: Subscriptions

## POST /api/subscriptions

- Description: Add a new subscription URL (trim + validate). Returns 201 on success.
- Request Body (application/json):

```json
{ "url": "https://example.com/feed" }
```

- Responses:
  - `201 Created` — body: subscription object (see Data Model)
  - `400 Bad Request` — validation errors (e.g., invalid URL, duplicate)

Example success response:

```http
HTTP/1.1 201 Created
Content-Type: application/json

{ "url": "https://example.com/feed", "createdAt": "2026-05-22T12:00:00Z" }
```

## GET /api/subscriptions

- Description: Return the list of current subscriptions (in-memory for MVP).
- Responses:
  - `200 OK` — body: array of subscription objects

Example response:

```json
[
  { "url": "https://example.com/feed", "createdAt": "2026-05-22T12:00:00Z" }
]
```
