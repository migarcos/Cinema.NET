# 🎬 Cinema.NET

Cinema.NET is a Blazor Server application designed to manage cinema operations such as auditoriums, movie showings, and ticket sales.  
It serves as a teaching project to demonstrate modern .NET development, Blazor components, and clean architecture practices.

---

## ✨ Features
- **Auditorium Management**: Create and configure auditoriums with seating layouts.
- **Movie Showings**: Schedule movies with times and auditoriums.
- **Ticket Sales**: Navigate to ticket-selling pages with dynamic routing.
- **Validation**: Built-in data annotations for input validation.
- **Services Layer**: Encapsulated business logic (`AuditoriumService`, `ShowingService`).
- **Navigation**: Sidebar menu with `NavLink` highlighting active routes.

---

## 🛠️ Tech Stack
- **.NET 8** (Blazor Server)
- **C#** for backend logic
- **Razor Components** for UI
- **Bootstrap** for styling
- **Entity Framework Core (optional)** for persistence

---

## 🚀 Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022 or VS Code

### Installation
1. Clone the repository:
   ```
   git clone https://github.com/migarcos/Cinema.NET.git
   cd Cinema.NET
2. Restore dependencies
    ```
    dotnet restore
    ```
3. Run the project:
    ```bash
    dotnet run
    dotnet watch
    ```

## 📂 Project Structure
    Cinema.NET/
    │
    ├── Pages/                # Razor pages (Auditoriums.razor, Showings.razor, etc.)
    ├── Services/             # Business logic services
    ├── Models/               # Domain models (Movie, Auditorium, Showing, Chair)
    ├── Shared/               # Shared components (NavMenu, MainLayout)
    ├── wwwroot/              # Static assets (CSS, JS, icons)
    └── Program.cs            # App startup and DI configuration

## 📜 License
This project is licensed under the MIT License.
See [Looks like the result wasn't safe to show. Let's switch things up and try something else!] for details.