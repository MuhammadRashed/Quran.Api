# Quran.Api
Quran API Built on ASP.NET Core Web API


## Installation
0- Change `DocumentationFile` in `src\Quran.Api\Quran.Api.csproj` to a local path

1- Build project and restore packages

2- Setup default connection string in `appsettings.json` file  under `Quran.Api` Project

3- In package manager execute ```update-database```, this will creates the database (sql server or sql express)

4- Run the project `Quran.Api`, you will get the following screenshot:

![Screenshot](/Screenshot.png)

## Dependencies

This project used main data files from https://github.com/semarketir/quranjson