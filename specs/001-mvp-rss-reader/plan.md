# Implementation Plan: MVP RSS Reader

**Branch**: `001-mvp-rss-reader` | **Date**: 2026-05-22 | **Spec**: [spec.md](spec.md#L1)

**Input**: Feature specification from `/specs/001-mvp-rss-reader/spec.md`

## Summary

Deliver a minimal, single-user RSS subscription manager: a Blazor WebAssembly frontend talking to an ASP.NET Core Web API backend. The MVP implements adding a subscription URL (trim + syntactic validation) and displaying the in-memory subscription list. No feed fetching, parsing, or persistence.

## Technical Context

**Language/Version**: NEEDS CLARIFICATION (recommended: .NET 8)

**Primary Dependencies**: ASP.NET Core Web API, Blazor WebAssembly, xUnit (testing)

**Storage**: In-memory collection (List<Subscription> / List<string>)

**Testing**: xUnit for backend unit tests; component tests for Blazor where feasible

**Target Platform**: Cross-platform (Windows/macOS/Linux) with WASM frontend

**Project Type**: Web application (separate `backend/` and `frontend/` projects)

**Performance Goals**: Not applicable for MVP; responsiveness target: add→list visible within 1s (acceptance)

**Constraints**: Follow project constitution: validate and sanitize inputs; MVP must not fetch or parse feeds; keep design simple and testable.

**Scale/Scope**: Single-user local POC; no persistence; minimal surface area for testing.

## Constitution Check

Gate: The constitution requires secure input handling and that the MVP avoid feed fetching. This plan complies by (1) enforcing syntactic URL validation and trimming before storage, and (2) restricting implementation to add/list behavior with in-memory storage. No gates violated.

## Project Structure

### Documentation (this feature)

```text
specs/001-mvp-rss-reader/
├── plan.md
├── research.md
├── data-model.md
├── quickstart.md
├── contracts/
└── tasks.md
```

### Source Code (selected layout: Web application)

```text
backend/                     # ASP.NET Core Web API
├── RSSFeedReader.Api/
│   ├── Program.cs
│   ├── Controllers/
│   └── Services/

frontend/                    # Blazor WebAssembly
├── RSSFeedReader.UI/
│   ├── Pages/
│   ├── Components/
│   └── wwwroot/

tests/
├── backend.unit/
└── frontend.components/
```

**Structure Decision**: Choose a two-project web app (`backend/` + `frontend/`) to match the TechStack and support clear separation of concerns between API and UI. This aligns with the constitution's maintainable, layered architecture requirement.

## Phase 0: Research (outline)

- Resolve any remaining tool/version choices (e.g., exact .NET SDK version)
- Confirm testing strategy for Blazor components (tools and scope)
- Produce `research.md` documenting decisions and rationale

## Phase 1: Design & Contracts (outline)

- Produce `data-model.md` with `Subscription` entity (URL:string, CreatedAt:DateTime?) and validation rules
- Create `contracts/` with API contract: `POST /api/subscriptions` (add), `GET /api/subscriptions` (list)
- Produce `quickstart.md` with local run instructions for backend and frontend

## Outputs

- `specs/001-mvp-rss-reader/research.md` (Phase 0)
- `specs/001-mvp-rss-reader/data-model.md`, `contracts/*`, `quickstart.md` (Phase 1)
- Update `.github/copilot-instructions.md` agent context to reference this `plan.md`
# Implementation Plan: [FEATURE]

**Branch**: `[###-feature-name]` | **Date**: [DATE] | **Spec**: [link]

**Input**: Feature specification from `/specs/[###-feature-name]/spec.md`

**Note**: This template is filled in by the `/speckit.plan` command. See `.specify/templates/plan-template.md` for the execution workflow.

## Summary

[Extract from feature spec: primary requirement + technical approach from research]

## Technical Context

<!--
  ACTION REQUIRED: Replace the content in this section with the technical details
  for the project. The structure here is presented in advisory capacity to guide
  the iteration process.
-->

**Language/Version**: [e.g., Python 3.11, Swift 5.9, Rust 1.75 or NEEDS CLARIFICATION]

**Primary Dependencies**: [e.g., FastAPI, UIKit, LLVM or NEEDS CLARIFICATION]

**Storage**: [if applicable, e.g., PostgreSQL, CoreData, files or N/A]

**Testing**: [e.g., pytest, XCTest, cargo test or NEEDS CLARIFICATION]

**Target Platform**: [e.g., Linux server, iOS 15+, WASM or NEEDS CLARIFICATION]

**Project Type**: [e.g., library/cli/web-service/mobile-app/compiler/desktop-app or NEEDS CLARIFICATION]

**Performance Goals**: [domain-specific, e.g., 1000 req/s, 10k lines/sec, 60 fps or NEEDS CLARIFICATION]

**Constraints**: [domain-specific, e.g., <200ms p95, <100MB memory, offline-capable or NEEDS CLARIFICATION]

**Scale/Scope**: [domain-specific, e.g., 10k users, 1M LOC, 50 screens or NEEDS CLARIFICATION]

## Constitution Check

*GATE: Must pass before Phase 0 research. Re-check after Phase 1 design.*

[Gates determined based on constitution file]

## Project Structure

### Documentation (this feature)

```text
specs/[###-feature]/
├── plan.md              # This file (/speckit.plan command output)
├── research.md          # Phase 0 output (/speckit.plan command)
├── data-model.md        # Phase 1 output (/speckit.plan command)
├── quickstart.md        # Phase 1 output (/speckit.plan command)
├── contracts/           # Phase 1 output (/speckit.plan command)
└── tasks.md             # Phase 2 output (/speckit.tasks command - NOT created by /speckit.plan)
```

### Source Code (repository root)
<!--
  ACTION REQUIRED: Replace the placeholder tree below with the concrete layout
  for this feature. Delete unused options and expand the chosen structure with
  real paths (e.g., apps/admin, packages/something). The delivered plan must
  not include Option labels.
-->

```text
# [REMOVE IF UNUSED] Option 1: Single project (DEFAULT)
src/
├── models/
├── services/
├── cli/
└── lib/

tests/
├── contract/
├── integration/
└── unit/

# [REMOVE IF UNUSED] Option 2: Web application (when "frontend" + "backend" detected)
backend/
├── src/
│   ├── models/
│   ├── services/
│   └── api/
└── tests/

frontend/
├── src/
│   ├── components/
│   ├── pages/
│   └── services/
└── tests/

# [REMOVE IF UNUSED] Option 3: Mobile + API (when "iOS/Android" detected)
api/
└── [same as backend above]

ios/ or android/
└── [platform-specific structure: feature modules, UI flows, platform tests]
```

**Structure Decision**: [Document the selected structure and reference the real
directories captured above]

## Complexity Tracking

> **Fill ONLY if Constitution Check has violations that must be justified**

| Violation | Why Needed | Simpler Alternative Rejected Because |
|-----------|------------|-------------------------------------|
| [e.g., 4th project] | [current need] | [why 3 projects insufficient] |
| [e.g., Repository pattern] | [specific problem] | [why direct DB access insufficient] |
