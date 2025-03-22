# Student Registration System

The **Student Registration System** is a modern, colorful, and stylish Windows Forms application developed in C# (.NET Framework 4.8). This system allows users to register students, save their information in an SQLite database, and view registered students within the application.

## Key Features
✅ Modern UI with light & dark mode  
✅ Student Registration Form (Form1 - `RegistrationForm`)  
✅ Student Details Viewer (Form2 - `StudentDetails`)  
✅ Mandatory fields (No empty submissions)  
✅ Automatic reset after each registration  
✅ Data stored inside the project (SQLite database)  
✅ View saved student records in `StudentDetails` form  

## Technology Stack
- **Programming Language:** C#
- **Framework:** .NET Framework 4.8
- **Database:** SQLite (Embedded inside the project)
- **UI Framework:** WinForms

## Project Structure
```
📂 StudentRegistrationSystem (Project Root)
├── 📄 Program.cs (Application Entry Point)
├── 📄 RegistrationForm.cs (Student Registration UI & Logic)
├── 📄 StudentDetails.cs (Displays Registered Students)
├── 📄 DatabaseHelper.cs (Handles SQLite Database Operations)
├── 📄 student.db (SQLite Database - Inside the Project)
├── 📂 bin/Debug (Output Directory - Stores Database File at Runtime)
└── 📂 obj (Temporary Build Files)
```

## How to Run the Project
1. **Clone or Download** the project.
2. **Open the project** in Visual Studio.
3. **Ensure that `student.db` exists** in the project directory.
4. **Set Copy to Output Directory for `student.db`**:
   - Right-click `student.db` → Properties → Set `Copy to Output Directory` to **Copy if newer**.
5. **Build the project**:
   - Click **Build** → **Rebuild Solution**.
6. **Run the application** (`F5`).
7. **Register students** and view the saved details.

## Troubleshooting
### 🔹 Getting database errors?
- Ensure `student.db` exists inside the project folder.
- Make sure it's set to **Copy if newer** in properties.
- Try **cleaning and rebuilding** the project.

### 🔹 Student details not updating?
- Close and reopen the `StudentDetails` form to refresh the data.
