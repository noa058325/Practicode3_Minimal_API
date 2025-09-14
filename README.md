# Practicode3 Minimal API

## Project Description
This project is a **Minimal API for a To-Do List application**, built using **.NET Core** for the backend and **React** for the frontend.  
It allows users to create, update, delete, and mark tasks as completed, as well as view all existing tasks.

---

## Technologies Used
- **Backend:** .NET Core Minimal API  
- **Frontend:** React, JavaScript, HTML, CSS  
- **Data:** In-memory storage for tasks (can be extended to a database in the future)

---

## Key Features
- Create a new task with a description, due date, and status  
- Update an existing task  
- Delete a task  
- Display all tasks in a list  
- Filter tasks by status (completed / not completed)

---

## Project Structure
```
/Practicode3_Minimal_API
│
├─ /ClientApp         # React frontend
├─ /Server            # .NET Core Minimal API
└─ README.md
```

---

## How to Run

### Backend
1. Open the `Server` folder in Visual Studio or VS Code  
2. Run the project using:
   ```bash
   dotnet run
   ```  
3. The API will be available at `https://localhost:5001`  

### Frontend
1. Open the `ClientApp` folder  
2. Install dependencies:
   ```bash
   npm install
   ```  
3. Start the React app:
   ```bash
   npm start
   ```  
4. Your browser will open the UI to manage tasks

---

## Possible Future Improvements
- Connect to a real database (SQL Server, SQLite, etc.)  
- Add user authentication and authorization  
- Enhance the UI with better design  
- Add automated tests (Unit & Integration)  
- Advanced task filtering and sorting

---

## Author
Noa Herbert – Software Engineering Graduate
