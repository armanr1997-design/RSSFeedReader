# Tasks: MVP RSS Reader

**Input**: Design documents from `/specs/001-mvp-rss-reader/` (plan.md, spec.md, data-model.md, contracts/)

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Project initialization and basic structure for backend and frontend

- [ ] T001 Create backend project `backend/RSSFeedReader.Api/RSSFeedReader.Api.csproj`
- [ ] T002 Create frontend Blazor WebAssembly project `frontend/RSSFeedReader.UI/RSSFeedReader.UI.csproj`
- [ ] T003 Create solution and add projects `RSSFeedReader.sln` (repo root)
- [ ] T004 Initialize `README.md` and minimal `launchSettings.json` files in both projects
- [ ] T005 [P] Add `.editorconfig` and repository-level dev guidance files
- [ ] T006 [P] Add CI/dev dependencies scaffold (GitHub Actions workflow template) in `.github/workflows/`

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Core infrastructure that MUST be complete before user stories

- [ ] T007 Configure backend CORS and base routing in `backend/RSSFeedReader.Api/Program.cs`
- [ ] T008 Create `backend/RSSFeedReader.Api/Models/Subscription.cs` (data model per `data-model.md`)
- [ ] T009 Implement in-memory subscription store `backend/RSSFeedReader.Api/Services/SubscriptionStore.cs`
- [ ] T010 Implement subscription service `backend/RSSFeedReader.Api/Services/SubscriptionService.cs` (validation, duplicate checks)
- [ ] T011 Implement API controller `backend/RSSFeedReader.Api/Controllers/SubscriptionsController.cs` with `POST /api/subscriptions` and `GET /api/subscriptions`
- [ ] T012 [P] Add backend unit tests for validation and store behavior `tests/backend.unit/SubscriptionServiceTests.cs`
- [ ] T013 Wire frontend `HttpClient` base address from `frontend/RSSFeedReader.UI/wwwroot/appsettings.json` and register in `frontend/RSSFeedReader.UI/Program.cs`
- [ ] T014 [P] Create skeleton Blazor page `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor` and component folder `frontend/RSSFeedReader.UI/Components/`
- [ ] T015 [P] Add bUnit setup and initial component test file `tests/frontend.components/SubscriptionsComponentTests.cs`
 - [ ] T037 Remove Blazor template demo pages `frontend/RSSFeedReader.UI/Pages/Home.razor`, `frontend/RSSFeedReader.UI/Pages/Counter.razor`, `frontend/RSSFeedReader.UI/Pages/Weather.razor` and verify no ambiguous routes (per TechStack.md)
 - [ ] T038 Add timing verification task (E2E or scripted check) to assert add→list visible within 1s; document manual verification steps in `quickstart.md` if automated test not implemented

**Checkpoint**: Foundation ready — API endpoints exist and frontend project can call them locally

---

## Phase 3: User Story 1 - Add a Feed Subscription (Priority: P1) 🎯 MVP

**Goal**: Allow a user to enter a feed URL, validate/trim it, add to in-memory list, and display it immediately.

**Independent Test**: User can enter a valid URL and see it appear in the subscription list on the same page.

- [ ] T016 [P] [US1] Implement `frontend/RSSFeedReader.UI/Components/AddSubscription.razor` (input field + Add button)
- [ ] T017 [US1] Implement `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor` to display list and call API
- [ ] T018 [US1] Implement client-side trimming and simple URL scheme check in `AddSubscription.razor` (UI-level validation)
- [ ] T019 [US1] Implement POST handling in `SubscriptionsController` to accept `{ "url": "..." }` and return `201 Created` on success
- [ ] T020 [US1] Implement GET `/api/subscriptions` to return current list (controller method)
- [ ] T021 [US1] Add end-to-end verification script in `specs/001-mvp-rss-reader/quickstart.md` to confirm add→list flow
- [ ] T022 [US1] [P] Add component tests (bUnit) verifying input trimming, add action, and list rendering `tests/frontend.components/SubscriptionsComponentTests.cs`
- [ ] T023 [US1] Add backend unit tests to assert duplicate prevention and invalid URL rejection `tests/backend.unit/SubscriptionServiceTests.cs`

**Checkpoint**: US1 complete — user can add subscriptions and see them listed (MVP satisfied)

---

## Phase 4: User Story 2 - View the Subscription List (Priority: P1)

**Goal**: Display all current subscriptions in a readable list and preserve order.

**Independent Test**: After adding subscriptions, the list page shows each URL in insertion order.

- [ ] T024 [P] [US2] Implement ordered list rendering in `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor`
- [ ] T025 [US2] Ensure GET `/api/subscriptions` returns subscriptions in insertion order (controller/service)
- [ ] T026 [US2] Add component tests (bUnit) asserting multiple items display correctly `tests/frontend.components/SubscriptionsListTests.cs`
- [ ] T027 [US2] Add integration test to simulate add then fetch list `tests/integration/AddThenListTests.cs`

---

## Phase 5: User Story 3 - Prevent Invalid or Duplicate Subscriptions (Priority: P2)

**Goal**: Reject malformed, empty, whitespace-only, or duplicate URLs and present clear validation messages.

**Independent Test**: Attempting to add invalid or duplicate URLs yields a user-facing message and does not change the list.

- [ ] T028 [US3] Implement server-side validation (trim, Uri.TryCreate, scheme check) in `backend/RSSFeedReader.Api/Services/SubscriptionService.cs`
- [ ] T029 [US3] Implement duplicate check in `SubscriptionService` and return `400 Bad Request` with a clear error message when duplicate
- [ ] T030 [US3] Implement UI validation error display in `AddSubscription.razor` (show messages returned by API)
- [ ] T031 [US3] Add backend unit tests for invalid inputs and duplicates `tests/backend.unit/SubscriptionValidationTests.cs`
- [ ] T032 [US3] Add component tests asserting validation messages shown and list unchanged `tests/frontend.components/SubscriptionsValidationTests.cs`

---

## Phase N: Polish & Cross-Cutting Concerns

- [ ] T033 [P] Documentation updates: finalize `specs/001-mvp-rss-reader/quickstart.md` and `README.md`
- [ ] T034 Code cleanup and refactoring across backend/frontend
- [ ] T035 [P] Add logging and minimal telemetry to backend `backend/RSSFeedReader.Api/Program.cs`
- [ ] T036 [P] Run quickstart validation script/manual checklist in `specs/001-mvp-rss-reader/quickstart.md`

---

## Dependencies & Execution Order

- Setup (T001-T006): can start immediately. Many sub-tasks are parallelizable ([P]).
- Foundational (T007-T015): BLOCKS user stories — must complete before US work continues.
- User Stories (T016-T032): depend on Foundational completion. US1 and US2 are P1 and should be prioritized; US3 is P2.
- Polish (T033-T036): follow after user stories complete.

## Parallel Execution Examples

- Workstream A: Backend engineer implements T007-T011 and T028-T031 (validation + service)
- Workstream B: Frontend engineer implements T013-T017 and T018-T021 (HttpClient + UI + POST/GET wiring)
- Workstream C: QA/Tester implements T012, T015, T022, T026, T032 (tests)

## Summary

- Path to tasks file: `specs/001-mvp-rss-reader/tasks.md`
- Total tasks: 36 (T001–T036)
- Task count by story:
  - Setup/Foundation: 15 tasks (T001–T015)
  - US1 (P1): 8 tasks (T016–T023)
  - US2 (P1): 4 tasks (T024–T027)
  - US3 (P2): 5 tasks (T028–T032)
  - Polish: 4 tasks (T033–T036)
- Parallel opportunities: many tasks marked `[P]` (setup, tests, separate services/components) and independent user stories after foundational phase
- Independent test criteria:
  - US1: Add a valid URL and observe it in the list within 1s (manual + automated test)
  - US2: After multiple adds, view list and confirm all items present in order
  - US3: Adding invalid or duplicate entries returns clear errors and list unchanged
- Suggested MVP scope: Complete only US1 (T016–T023) after Foundational tasks — sufficient for an MVP demo

## Format validation

- All tasks use the checklist format `- [ ] T### [P?] [US?] Description with file path` as required.
