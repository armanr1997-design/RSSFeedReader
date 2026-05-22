# Data Model: MVP RSS Reader

## Entities

### Subscription

- **Url**: string — the feed URL; stored trimmed and normalized for duplicate checks
- **CreatedAt**: DateTime (UTC) — timestamp when subscription was added

Notes:
- For the MVP the primary identifier is the `Url` itself (no persistent numeric ID required). If a persistent store is later added, introduce an `Id: Guid`.
- Duplicate detection: perform a case-insensitive comparison against a normalized URL (trimmed, optional trailing slash removal). Store only the trimmed form.

## Validation Rules

- Trim leading/trailing whitespace before validation.
- Require syntactically valid absolute URI using `Uri.TryCreate(value, UriKind.Absolute, out var uri)`.
- Enforce scheme `http` or `https`.
- Reject empty or whitespace-only values.

Example (JSON representation returned by API):

```json
{
  "url": "https://example.com/feed",
  "createdAt": "2026-05-22T12:00:00Z"
}
```
