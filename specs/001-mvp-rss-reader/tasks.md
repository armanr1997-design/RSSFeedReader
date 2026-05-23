---
description: "Task list template for feature implementation"
---

# Tasks: MVP RSS Reader

**Input**: Design documents from `/specs/001-mvp-rss-reader/` (`plan.md`, `spec.md`, `data-model.md`, `contracts/`, `quickstart.md`)

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Create the solution and baseline backend/frontend/test structure.

- [X] T001 Create backend API project `backend/RSSFeedReader.Api/RSSFeedReader.Api.csproj`
- [X] T002 Create frontend Blazor WebAssembly project `frontend/RSSFeedReader.UI/RSSFeedReader.UI.csproj`
- [X] T003 Create solution `RSSFeedReader.slnx` and add backend/frontend/test projects
- [X] T004 Create initial `README.md` with MVP quickstart instructions
- [X] T005 [P] Add repository config files: `.editorconfig`, `.gitignore`
- [X] T006 [P] Add GitHub Actions workflow at `.github/workflows/dotnet.yml`
- [X] T007 [P] Create integration test project `tests/integration/integration.csproj`

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Implement shared backend and frontend infrastructure required by all stories.

- [X] T008 Configure backend routing and CORS in `backend/RSSFeedReader.Api/Program.cs`
- [X] T009 Create `backend/RSSFeedReader.Api/Models/Subscription.cs` based on `data-model.md`
- [X] T010 Create `backend/RSSFeedReader.Api/Models/AddSubscriptionRequest.cs`
- [X] T011 Implement `backend/RSSFeedReader.Api/Services/SubscriptionStore.cs`
- [X] T012 Implement `backend/RSSFeedReader.Api/Services/SubscriptionService.cs` with validation and duplicate handling
- [X] T013 Implement `backend/RSSFeedReader.Api/Controllers/SubscriptionsController.cs` for `GET /api/subscriptions` and `POST /api/subscriptions`
- [X] T014 [P] Configure frontend `HttpClient` base address in `frontend/RSSFeedReader.UI/Program.cs` and `frontend/RSSFeedReader.UI/wwwroot/appsettings.json`
- [X] T015 [P] Remove template pages `frontend/RSSFeedReader.UI/Pages/Home.razor`, `frontend/RSSFeedReader.UI/Pages/Counter.razor`, `frontend/RSSFeedReader.UI/Pages/Weather.razor`
- [X] T016 [P] Update `frontend/RSSFeedReader.UI/Layout/NavMenu.razor` to expose only the subscriptions page
- [X] T017 [P] Add backend unit test project `tests/backend.unit/backend.unit.csproj` and reference backend project
- [X] T018 [P] Add frontend component test project `tests/frontend.components/frontend.components.csproj` and reference frontend project
- [X] T019 [P] Add backend unit tests for core subscription behavior in `tests/backend.unit/SubscriptionServiceTests.cs`
- [X] T020 [P] Add frontend component test skeleton in `tests/frontend.components/SubscriptionsComponentTests.cs`

**Checkpoint**: Foundation ready — backend and frontend wiring exist and template cleanup is complete.

---

## Phase 3: User Story 1 - Add a Feed Subscription (Priority: P1) 🎯 MVP

**Goal**: Allow a user to enter a feed URL, validate/trim it, add it to the in-memory subscription list, and immediately see it displayed.

**Independent Test**: A valid URL is entered and appears in the subscription list on the same page.

- [X] T021 [P] [US1] Implement `frontend/RSSFeedReader.UI/Components/AddSubscription.razor` with URL input, Add button, and feedback message
- [X] T022 [US1] Implement `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor` to render the subscription list and call the add component
- [X] T023 [US1] Add client-side trimming and URL scheme validation in `AddSubscription.razor`
- [X] T024 [US1] Implement `POST /api/subscriptions` handling in `backend/RSSFeedReader.Api/Controllers/SubscriptionsController.cs`
- [X] T025 [US1] Implement `GET /api/subscriptions` in `SubscriptionsController.cs`
- [X] T026 [US1] Add component tests in `tests/frontend.components/SubscriptionsComponentTests.cs` verifying add flow and list rendering
- [X] T027 [US1] Add backend tests in `tests/backend.unit/SubscriptionServiceTests.cs` for valid add and storage behavior
- [X] T028 [US1] Document add-to-list verification in `specs/001-mvp-rss-reader/quickstart.md`

**Checkpoint**: US1 is independently testable and delivers the MVP add/list workflow.

---

## Phase 4: User Story 2 - View the Subscription List (Priority: P1)

**Goal**: Display all subscriptions in a readable ordered list so users can verify the current state.

**Independent Test**: After adding multiple subscriptions, the page shows each URL in insertion order.

- [X] T029 [P] [US2] Render ordered list entries in `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor`
- [X] T030 [US2] Preserve insertion order in `backend/RSSFeedReader.Api/Services/SubscriptionService.cs`
- [X] T031 [US2] Add component tests in `tests/frontend.components/SubscriptionsPageTests.cs` for multiple subscriptions
- [X] T032 [US2] Add integration test in `tests/integration/AddThenListTests.cs` covering add then list retrieval

---

## Phase 5: User Story 3 - Prevent Invalid or Duplicate Subscriptions (Priority: P2)

**Goal**: Reject malformed, empty, whitespace-only, or duplicate URLs with clear error feedback and no list mutation.

**Independent Test**: Invalid or duplicate submissions return visible errors and do not alter the list.

- [X] T033 [US3] Implement server-side validation in `backend/RSSFeedReader.Api/Services/SubscriptionService.cs`
- [X] T034 [US3] Implement duplicate detection and `400 Bad Request` response in `SubscriptionService.cs`
- [X] T035 [US3] Display validation errors in `frontend/RSSFeedReader.UI/Components/AddSubscription.razor`
- [X] T036 [US3] Add backend tests for invalid and duplicate subscriptions in `tests/backend.unit/SubscriptionServiceTests.cs`
- [X] T037 [US3] Add frontend validation tests in `tests/frontend.components/SubscriptionsComponentTests.cs`

---

## Phase N: Polish & Cross-Cutting Concerns

- [X] T038 [P] Finalize documentation updates in `specs/001-mvp-rss-reader/quickstart.md` and `README.md`
- [X] T039 Code cleanup and refactoring across backend/frontend files
- [X] T040 [P] Add logging and minimal telemetry scaffolding in `backend/RSSFeedReader.Api/Program.cs`
- [X] T041 [P] Validate the quickstart checklist in `specs/001-mvp-rss-reader/quickstart.md`

---

## Dependencies & Execution Order

- Setup (T001-T007): start immediately. Many tasks are parallelizable.
- Foundational (T008-T020): must complete before user story work begins.
- User Stories (T021-T037): depend on foundational completion.
- Polish (T038-T041): follow after user stories are implemented.

## Parallel Execution Examples

- Backend workstream: T008-T013, T019, T027, T033-T036
- Frontend workstream: T014-T016, T021-T023, T029, T031, T035
- QA workstream: T019, T020, T026, T032, T037, T041

## Summary

- Path to tasks file: `specs/001-mvp-rss-reader/tasks.md`
- Total tasks: 41 (T001–T041)
- Task count by area:
  - Setup/Foundation: 20 tasks (T001–T020)
  - US1: 8 tasks (T021–T028)
  - US2: 4 tasks (T029–T032)
  - US3: 5 tasks (T033–T037)
  - Polish: 4 tasks (T038–T041)
- Parallel opportunities: many `[P]` tasks in setup, testing, and separate backend/frontend work
- Independent test criteria:
  - US1: Add a valid URL and see it appear immediately
  - US2: After multiple adds, view list and confirm all items appear in order
  - US3: Invalid or duplicate entries return clear errors and no list change
- Suggested MVP scope: complete US1 after foundational setup, then extend to US2 and US3.

## Format validation

- All tasks use the checklist format `- [ ] T### [P?] [US?] Description with file path`
