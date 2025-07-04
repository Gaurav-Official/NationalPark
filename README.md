# 🌲 National Park Management System

A full-stack web application built using **ASP.NET Core Web API** for the backend and **ASP.NET Core MVC** for the frontend. This project manages National Parks data with secure user management, a clean separation of concerns, and scalable architecture patterns.

---

## 📌 Project Overview

The **National Park Management System** allows users to view, create, edit, and delete records of various national parks. It features a well-organized codebase using industry best practices like **Repository Pattern**, **Unit of Work**, **Generic Repositories**, **Dependency Injection**, and proper **Authentication & Authorization** mechanisms.

---

## 🚀 Tech Stack

- **Backend**: ASP.NET Core Web API
- **Frontend**: ASP.NET Core MVC
- **Database**: MSSQL Server (via Entity Framework Core)
- **Authentication**: Identity-based Authentication & Authorization, JWT Authentication
- **Architecture Patterns**:
  - Repository Pattern
  - Generic Repository
  - Unit of Work Pattern
  - Dependency Injection (built-in DI container)

---

## 📚 Key Features

✅ ASP.NET Core Web API for RESTful services  
✅ ASP.NET Core MVC application as a Frontend client  
✅ Generic Repository for reusable data access logic  
✅ Unit of Work to coordinate repository operations  
✅ Secure Authentication & Role-based Authorization  
✅ Dependency Injection for service & repository management  
✅ Entity Framework Core for database ORM  
✅ CRUD operations for managing National Park records  
✅ Clean, scalable and maintainable architecture  

---

## 📂 Project Structure

### 📦 API Project (Backend)

NationalParkAPI/
├── Controllers/
├── Data/
├── Models/
├── Repository/
├── Services/
├── Startup.cs / Program.cs
├── appsettings.json

shell
Copy
Edit

### 📦 MVC Project (Frontend)

NationalParkWeb/
├── Controllers/
├── Models/
├── Views/
├── wwwroot/
├── appsettings.json
├── Program.cs

---

## 📸 Screenshots

> 📌 *Add your project screenshots in a `/screenshots/` folder inside your repo and replace the image links below with your actual screenshots.*

### 🌲 National Parks List (MVC Web App)
![National Parks List](![Screenshot (29)](https://github.com/user-attachments/assets/d1df30ea-527c-44c8-9199-25780ac70272)
)

---

### ➕ Add New National Park Page
![Add National Park](![Screenshot (30)](https://github.com/user-attachments/assets/31859c4f-2725-4bdc-979f-1cfe04d37c2e)
![Screenshot (31)](https://github.com/user-attachments/assets/75ebd110-ca67-4c1f-bace-b9b8f83f5573)
)

---

### 📑 Swagger UI (API)
![Swagger UI](![Screenshot (33)](https://github.com/user-attachments/assets/facdcdab-343b-4af2-bffb-cc3100ad4552)
![Screenshot (32)](https://github.com/user-attachments/assets/70e65180-8c55-4b36-b0e3-9bf21734e0b9)
![Screenshot (34)](https://github.com/user-attachments/assets/45b7bfa5-a1ec-4042-9a2f-404476e1a784)
.png)

---

## 📦 How to Run

1️⃣ Open the solution in **Visual Studio 2022**  
2️⃣ Restore NuGet packages if prompted  
3️⃣ Update `appsettings.json` with your SQL Server connection string  
4️⃣ Apply migrations and update the database  
5️⃣ Run both API and MVC projects  
6️⃣ Access Swagger for API testing:  
`http://localhost:5000/swagger/index.html`

7️⃣ Access MVC application via browser:  
`http://localhost:5001/`

---

## 👨‍💻 Developed by:

**Gaurav Pandey**  
[GitHub Profile](https://github.com/Gaurav-Official)

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).
