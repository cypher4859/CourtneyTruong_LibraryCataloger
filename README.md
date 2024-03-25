LibraryCataloger 

LibraryCataloger is my final project for Code:Kentucky's Software Development Bootcamp. The app is a ASP.NET MVC app that uses a Sqlite database with Entity Framework Core. Views for the app are created using Bootstrap. The goal of this app was to create a simple app that a user can use to keep track of their personal book collections as well as keep track of books that they would like to read in the future via a "To Be Read List". A user is able to perform CRUD operations on books in their collection by adding a book to the database, reading list books in the database via "Your Library" and "To Be Read List" pages, updating information on each book and removing books from the database.

To Use, clone repository and follow the instructions below to update the database and then run the application.

Before running update the database:
1. right click on solution
2. click "open in terminal"
3. type "dotnet tool install --global dotnet-ef --version 8" and hit enter
4. type "dotnet ef database update" and hit enter

How to Start Application:
1. Open LibraryCataloger.Sln in Visual Studio
2. Run Debug or press F5
3. LibraryCataloger opens in browser window

Technologies/Languages/Libraries:
- C#
- ASP.NET MVC
- Bootstrap
- Entity Framework Core
- SQL Lite
- Nunit Testing with Moq


Software Development Capstone Features:
- Add comments to your code explaining how you are using at least 2 of the solid principles
- Create 3 or more unit tests for your application
- Make your application a CRUD API
