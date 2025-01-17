
# Grinch Console App

## Overview
Grinch is a .NET console application that uses Entity Framework Core with MySQL to perform database operations. 
This project demonstrates basic database functionalities and provides a foundation for further development.

## Requirements
1. .NET SDK 6.0 or later.
2. MySQL Server 8.0 or later.
3. Required NuGet Packages:
   - Microsoft.EntityFrameworkCore
   - Pomelo.EntityFrameworkCore.MySql
   - Microsoft.EntityFrameworkCore.Design

## Setup Instructions
1. Clone the repository and navigate to the project folder:
   ```bash
   git clone <repository-url>
   cd Grinch_5
   ```

2. Install the required NuGet packages:
   ```bash
   dotnet restore
   ```

3. Open the `AppDbContext` file located in the `Grinch.Data` folder.

4. Update the `OnConfiguring` method with your MySQL database credentials:
   ```csharp
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       optionsBuilder.UseMySql(
           "Server=localhost;Database=YourDatabaseName;User=YourUsername;Password=YourPassword;",
           new MySqlServerVersion(new Version(8, 0, 31)) // Replace with your MySQL version
       );
   }
   ```

5. Apply migrations and update the database schema:
   ```bash
   dotnet ef database update --context AppDbContext --project Grinch.Data
   ```

6. Run the application:
   ```bash
   dotnet run --project Grinch
   ```

## Usage
Modify the `Program.cs` file to perform the desired database operations, such as adding, updating, or querying records using `AppDbContext`.

## Commands
| Command                                 | Description                                      |
|-----------------------------------------|--------------------------------------------------|
| `dotnet restore`                        | Restores the NuGet packages for the project.    |
| `dotnet ef database update`             | Applies migrations and updates the database.    |
| `dotnet run --project Grinch`           | Runs the console application.                   |

## Support
If you encounter any issues, please contact the project maintainers or open an issue in the repository.

## License
This project is licensed under the MIT License. See the LICENSE file for details.
