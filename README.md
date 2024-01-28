 **# README**
**# TECHSTACK: .NET8.0, .NET Standard 4.75, Docker**
**# Tools Used: Sql Server Mangaement Studio 18, Microsoft Visual Studio 2022**
**## Project Overview**

This repository contains two .NET API projects (.Net 8.0 ), 4 class library (.NET Framework 4.7.2), 1 console project (.NET Framework 4.7.2) and a test folder for testing 
other dotnet projects before deploying it to product which contains a console application (.Net Framework 4.7.2):

- **NT.WebApi2 (.NET 8):** 
    - Contains list of api methods to create, read, update, delete a note in a database. Contain api method to save a note.
  **.NT.WebApiClient (.NET 8):** 
    - Development in Progress  
- **NT.Model (.NET 4.7.5 Standard Class Library ):** 
    contains Note class
  **NT.DataInterface (.NET 4.7.5 Standard Class Library ):** 
    contains INTRepository Interface
  **NT.DataDapper (.NET 4.7.5 Standard Class Library ):** 
    contains NTRepository Interface
  **NT.Data (.NET 4.7.5 Standard Class Library ):** 
    - contains NTRepository Interface and implemnent INTRepository
    - - connects to database with connection string
      - contains logging object log with type ILog
    - perform logging using Log4Net Nuget package 
    - Contains GetAll(), Delete(Note), Update(Note n), DeleteById(Guid id), Insert(Note n)
  **NT.Console (.NET 4.7.5 Standard Console Project ):** 
    outputs the test results on console for the different Note methods when run

Api .Net 8 projects run on docker. 

**## Development Environment**

- **Visual Studio 2022**
- **.NET 8 SDK**
- **.NET 4.7.5 SDK (for Project B)**
- **Docker Desktop**

**## Getting Started**

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Calebyang93/ToDoList.git.git
   ```

2. **Open the solution in Visual Studio 2022.**

3. **Build the projects:**
   - Right-click on the solution in Solution Explorer and select "Rebuild Solution."

4. **Run the projects in Docker:**
   - **For NT.WebApi2 Project (*.Net 8)**
      - Open a terminal in the project directory and run:
      ```bash
      docker build -t project-a .
      docker run -p 8080:80 project-a
      ```
   - **For NT.WebApiClient**
   - **Don't run yet as not tested**
      - Open a terminal in the project directory and run:
      ```bash
      docker build -t project-b .
      docker run -p 8081:80 project-b
      ```

**## Project Structure**
  
- **Test**
    - Dev.Dapper (.Net Framework 4.7.2)
        - Program.cs
        - Properties
        - References
        - App.Config
        - packages.config
- **Solution NoteTaker **
    - **Test**
    - NT.Console
      - Program.cs
      - Properties
      - References
      - App.Config
      - packages.config
    - NT.Data
      - NTRepository.cs
      - Properties
      - References
      - App.Config
      - packages.config
    - NT.DataDapper
      - NTRepository.cs
      - Properties
      - References
      - App.Config
      - packages.config
    - NT.DataInterface
      - INTRepository.cs
      - Properties
      - References
      - App.Config
      - packages.config
    - NT.Model
      - Properties
      - References
      - Note.cs
    - NT.WebApi2
      - ConnectedServices
      - Dependencies
      - Properties
      - Controllers
        - ITDoListService.cs
        - MockNotesController.cs
        - Note2.cs
        - NoteController.cs
        - WeatherForecastController.cs
      - appsettings.json
      - DockerFile
        -.dockerignore
      -index.html
      -NT.WebApi2.http
      -Program.cs
      -WeatherForecast.cs
    - NT.WebApiClient
       - ConnectedServices
      - Dependencies
      - Properties
      - Controllers
        - MockNotesController.cs
      - appsettings.json
      - DockerFile
        -.dockerignore
      -NT.WebApi2.http
      -Program.cs


**## Additional Information**

- [Provide any other relevant details about the projects, such as external dependencies, configuration files, or usage instructions]
**Nuget Packages Used : log4net, Dapper, DapperContrib, Newtonsoft.Json, Microsoft.ServiceFabric.Diagnostics.Internal, Swashbuckle.AspNetCore** 
  
**## Contributing**

Read contributing.md before contributing to this project as an open source developer. 

**## License**

This project is licensed under the MIT License: LICENSE.
