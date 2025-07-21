📘 Outbooked: Final Project README

🧩 Overview

Outbooked is a streamlined event management platform built using ASP.NET Core Razor Pages. It focuses on efficient booking workflows, conflict detection, and intuitive UI—all while running completely on mock data, making it ideal for demos and proof-of-concept deployments.

🛠️ Features
- Event creation, editing, and deletion via clean Razor UI
- Manual Outlook calendar sync with visual feedback
- Real-time conflict detection using TripleSeatService
- Status-driven event labeling (Lead, Pending, Confirmed, Synced)
- Toast-based feedback for user interactions
- Bootstrap-powered responsive layout
- Dedicated test project with unit coverage for core logic

🧪 Test Coverage
The Outbooked.Tests project includes key unit tests for:
- Detecting event overlaps (via ConflictExists)
- Ensuring proper temporal boundary handling
- Verifying edge cases with time-based logic

🚀 Running the App
- Clone the repo
- Set Outbooked.Web as the startup project
- Run in Visual Studio or via dotnet run
- Navigate to /Events to manage bookings
- Use the “Sync Outlook” button to mark Confirmed events as Synced
No database or external API calls required—runs entirely in-memory.

📦 Tech Stack
- ASP.NET Core Razor Pages
- Bootstrap 5
- xUnit
- C# (.NET 8)
- Mock services and repositories

📚 Course Concepts Demonstrated

- Razor Page architecture and routing
- Service injection via DI container
- Unit testing with xUnit
- Clean separation of concerns
- UI feedback patterns and layout styling
- In-memory data managementexplain 

📝 Final Project Summary
Outbooked is a fully functional Razor Pages app built from the ground up using clean architecture principles. It demonstrates mastery of .NET web development, from UI polish and page routing to service layering and test coverage.
The app supports manual Outlook sync via a custom service, shows visual status tags for each event, and uses a lightweight toast system for user feedback—all without relying on external dependencies or EF Core. Core business logic like conflict detection is fully unit tested in a dedicated test project.
Outbooked’s modular design, professional styling, and thoughtful UX prove a comprehensive understanding of ASP.NET Core and practical software engineering.

