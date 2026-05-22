# Research: Technical Decisions for MVP RSS Reader

## Decision: .NET SDK Version

- Decision: Use .NET 8 (LTS/Current as of 2026) for both backend and Blazor WebAssembly frontend.
- Rationale: .NET 8 provides the latest stable features, improved performance, and long-term support alignment for new projects initiated in 2026. It also matches common templates and tooling for ASP.NET Core + Blazor.
- Alternatives considered:
  - .NET 7: supported but not preferred for new greenfield projects in 2026.
  - .NET 6: older LTS, but misses language/runtime improvements.

## Decision: Testing Strategy

- Backend: xUnit for unit tests (service layer) and minimal integration tests for controllers.
- Frontend: use bUnit for Blazor component tests for critical UI behavior (input trimming/validation and list rendering).
- Rationale: xUnit and bUnit are well-supported, cross-platform, and integrate into CI pipelines. They allow fast, focused tests for the MVP behaviors required by the spec.

## Decision: URL Validation Approach

- Decision: Syntactic URL validation using `Uri.TryCreate(..., UriKind.Absolute)` plus trimming and a simple scheme check (http/https). Do NOT attempt network validation or feed discovery.
- Rationale: Syntactic checks satisfy acceptance criteria, are fast, and avoid network dependencies that would complicate the MVP and violate constitution constraints.

## Decision: API Contract (high level)

- `POST /api/subscriptions` — body: `{ "url": "https://..." }` — validates and, on success, returns 201 Created with the subscription resource or 400 with validation errors.
- `GET /api/subscriptions` — returns `200 OK` with array of subscription objects.

## Open Questions (resolved)

- .NET version: decided = .NET 8
- Blazor component testing: decided = use bUnit

## Conclusion

All previous NEEDS_CLARIFICATION items in the plan are resolved. The implementation can proceed to Phase 1 design and artifact generation.
