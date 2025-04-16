# 🔐 Role-Based Authentication API (JWT + EF Core 8)

This is a sample .NET Core 8 Web API project demonstrating **Role-Based Authentication** using **JWT tokens** and **Entity Framework Core 8** with roles stored in the database.


## 📌 Features

- ✅ User login with token generation
- ✅ Roles stored in the database (e.g., Admin, User)
- ✅ Role-based authorization on API endpoints
- ✅ JWT token authentication
- ✅ Database seeding with initial users
- ✅ Swagger integrated with JWT support


## 🛠️ Technologies Used

- ASP.NET Core 8 Web API
- Entity Framework Core 8
- JWT (JSON Web Tokens)
- SQL Server
- Swagger / Swashbuckle
- NLog 


## 🧱 Database Schema

### `User` Table
| Field     | Type    |
|-----------|---------|
| Id        | int     |
| Username  | string  |
| Password  | string  |
| Role      | string  |

Seeded users:
```json
[
  { "Username": "admin", "Password": "admin123", "Role": "Admin" },
  { "Username": "user", "Password": "user123", "Role": "User" }
]
```
## 🚀 Getting Started
#### Step 1: Clone the Repository
git clone https://github.com/your-username/RoleBasedAuthAPI.git 

#### Step 2: Setup Connection String
Update appsettings.json with your SQL Server connection:
```code
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=RoleAuthDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```
#### Step 3: Run Migrations
```
Add-Migration InitialCreate
Update-Database
```
This will create the database and seed initial users.

### 🔧 JWT Configuration (Program.cs)
```
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("Your_Secret_Key_Here"))
    };
});
```
### 📚 License
This project is for educational/demo purposes only. Free to use, improve, and share 🚀
