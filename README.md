# Customer Feedback System

## Introduction
The Customer Feedback System is an ASP.NET Core MVC web application that facilitates the collection of customer feedback. It provides functionalities for submitting feedback, categorizing it, as well as viewing, editing, and deleting feedback entries.

## Setting Up

### Prerequisites
- .NET Core SDK (Version corresponding to the project, e.g., 3.1, 5.0, etc.)
- Azure SQL Database or a local SQL Server instance
- Visual Studio or another suitable code editor with C# and ASP.NET Core support

### Running the Application Locally

1. **Clone the Repository**: Clone the project repository from GitHub to your local machine.

   ```sh
   git clone https://github.com/yourusername/CustomerFeedbackSystem.git

2. Open the Solution: Open the CustomerFeedbackSystem.sln file in Visual Studio.

3. Restore NuGet Packages: Use Visual Studio's NuGet package manager to restore all the dependencies.

4. Configure the Database: Update the appsettings.json file with your Azure SQL database connection string. For the purpose of initial tests, a simple password is used, but for any real environment, Azure Key Vault or another secret management tool should be used to secure credentials.

   ```sh
   "ConnectionStrings": { "DefaultConnection": "{appsettings.json}"}


5. Apply Migrations: Use Entity Framework Core to apply the migrations and set up the database schema: 

   ```sh
   dotnet ef database update

6. Run the Application: Start the application using Visual Studio's "IIS Express" button or the dotnet run command from the terminal.

# Design Pattern
The Repository Pattern has been implemented to manage data operations. This abstraction between the data access logic and the business logic layers helps maintain clean code separation and improves maintainability.

## Assumptions & Design Decisions
- For simplicity in this demo, the database credentials are included directly in the appsettings.json. However, in a production setting, credentials would be secured using Azure Key Vault to manage secrets safely.
- The system currently assumes that it will be deployed within a secure internal network and hence does not implement comprehensive user authentication.
-Predefined categories are assumed for feedback classification.

## Development Strategies
### Branch Management
A simple branching strategy has been employed:

- main branch: Holds the production-ready state of the application.
- develop branch: Serves as the integration branch for all features.
- Feature branches: Created for each new feature and merged back into develop once the feature is completed and tested.
- Releases: Tagged from main after rigorous testing and hotfixes are merged back into both main and develop.

## Documentation
Comments and documentation within the codebase adhere to standard C# XML documentation practices, facilitating maintainability and future development.