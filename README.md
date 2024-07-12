# .NET Core Web API application

This project involves a .NET Core Web API application that manages user profiles and tracks running activity. I utilize Entity Framework as the Object-Relational Mapping (ORM) tool and NLOG for logging, and XUnit for unit testing, the project utilizes Swagger UI for API testing..
The application comprises two tables: one for storing user profile data and another for running activity records, linked via a userId. Both user profiles and running activities support Create, Read, Update, and Delete (CRUD) operations.


Here are the details for the calculated fields:
<img alt="calculated-fields.jpg" src="https://github.com/ZaldyJegPiraman/RunningAppAPI/blob/main/calculated-fields.jpg?raw=true" data-hpc="true" class="Box-sc-g0xbh4-0 kzRgrI">


## Project Setup
	Change connection string in appSettings.json base on your database credentials
	Open nuget package manager console then restore packages
    
## Run Nuget command
    update-database
	dotnet run seeddata
 
<p style="color:red;">Note: click "stop command execution" after running dotnet run to avoid System.IO.IOException error</p>

## Run the app
	Default URL:
    https://localhost:7219/index.html

## Run the tests

    ./run-tests.sh
    
## Project Log Directory
	   {Project Debug Folder}/net6.0/Logs/{date}/InfoLog.txt



