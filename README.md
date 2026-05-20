# VidyaSar ERP — .NET Core 8 Web API

Converted from the original **Spring Boot 3 (Java 21)** project.  
Architecture follows **Clean Architecture** (Domain → Application → Infrastructure → API).

---

## Project Structure

```
VidyaSar.sln
└── src/
    ├── VidyaSar.Domain/               # Entities only – no dependencies
    │   └── Entities/
    │       ├── UserProfile.cs
    │       ├── University.cs
    │       ├── College.cs
    │       ├── EducationGroup.cs
    │       ├── SessionMaster.cs
    │       └── Configurations.cs      # Academic / Admission / Exam / Fees / Library
    │
    ├── VidyaSar.Application/          # Business logic – depends on Domain only
    │   ├── Common/
    │   │   └── ApiResponse.cs
    │   ├── DTOs/
    │   │   └── Dtos.cs
    │   ├── Interfaces/
    │   │   ├── IServices.cs
    │   │   ├── IRepositories.cs
    │   │   └── IJwtService.cs
    │   └── Services/
    │       └── Services.cs            # Auth / Common / University / Group / Session / Institute
    │
    ├── VidyaSar.Infrastructure/       # EF Core, JWT, BCrypt – depends on Application
    │   ├── Data/
    │   │   └── AppDbContext.cs
    │   ├── Repositories/
    │   │   └── Repositories.cs
    │   ├── Security/
    │   │   └── JwtService.cs
    │   └── Extensions/
    │       └── ServiceExtensions.cs
    │
    └── VidyaSar.API/                  # ASP.NET Core Web API – entry point
        ├── Controllers/
        │   └── Controllers.cs         # Auth / Common / University / Group / Session / Institute
        ├── Middleware/
        │   └── JwtMiddleware.cs
        ├── appsettings.json
        ├── appsettings.Development.json
        └── Program.cs
```

---

## Java → .NET Mapping

| Java / Spring Boot           | .NET Core 8                          |
|------------------------------|--------------------------------------|
| `@SpringBootApplication`     | `Program.cs` + `WebApplication`      |
| `@RestController`            | `[ApiController]` + `ControllerBase` |
| `@RequestMapping`            | `[Route]`                            |
| `@PostMapping`               | `[HttpPost]`                         |
| `@Service`                   | Scoped service via DI                |
| `JpaRepository`              | `DbContext` + EF Core repository     |
| `BCryptPasswordEncoder`      | `BCrypt.Net-Next`                    |
| `jjwt`                       | `System.IdentityModel.Tokens.Jwt`    |
| `application.properties`     | `appsettings.json`                   |
| `Spring Security`            | `Microsoft.AspNetCore.Authentication`|
| `@Transactional`             | `DbContext.SaveChangesAsync()`       |
| `Lombok @Data`               | C# auto-properties                   |

---

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- PostgreSQL 14+

---

## Getting Started

```bash
# 1. Restore packages
dotnet restore

# 2. Update DB connection in appsettings.Development.json

# 3. Apply EF migrations
cd src/VidyaSar.API
dotnet ef migrations add InitialCreate --project ../VidyaSar.Infrastructure
dotnet ef database update

# 4. Run
dotnet run --project src/VidyaSar.API
```

Swagger UI: **http://localhost:5000** (or https://localhost:5001)

---

## API Endpoints

| Method | Route                          | Auth     | Description              |
|--------|--------------------------------|----------|--------------------------|
| POST   | `/api/auth/login`              | Public   | Login, returns JWT       |
| POST   | `/api/common/reset-password`   | Bearer   | Reset password           |
| POST   | `/api/university/add-update`   | Bearer   | Add / update university  |
| POST   | `/api/group/add-update`        | Bearer   | Add / update edu group   |
| POST   | `/api/session/add-update`      | Bearer   | Add / update session     |
| POST   | `/api/institute/add-update`    | Bearer   | Add / update institute   |

---

## Default Credentials (auto-created on new institute)

| User ID            | Password       | Role           |
|--------------------|----------------|----------------|
| `{collegeId}1001`  | `Password@123` | Site Admin (1) |
| `{collegeId}1004`  | `Password@123` | Principal (4)  |
